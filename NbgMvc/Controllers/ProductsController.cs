using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using NbgCrmCore.Model;
using NbgCrmCore.Repository;
using NbgMvc.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace NbgMvc.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductRepository productRepository;
        private readonly IHostEnvironment hostEnvironment;


        public ProductsController(IProductRepository _productRepository,
            IHostEnvironment hostEnvironment
            )
        {
            productRepository = _productRepository;
            this.hostEnvironment = hostEnvironment;
        }
        // GET: ProductsController
        public ActionResult Index([FromQuery] int pageSize=1, [FromQuery] int pageCount=1)
        {

            if (pageCount <= 0) pageCount = 1;
           
            List<Product> products = productRepository
                .RetreiveEntities(pageCount, pageSize).ToList();
            ProductsPage productsPage = new() { Products = products,
                PageCount = pageCount  ,
                PageNext= pageCount +1,
                PagePrevious = pageCount - 1 ,
            };

            return View("List", productsPage);
        }

        // GET: ProductsController/Details/5
        public ActionResult Details([FromRoute] int id)
        {
            
            Product product = productRepository.RetreiveEntity(id).ReturnData;
            return View(product);
        }

        // GET: ProductsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                Product product = new() { 
                    Name = collection["Name"], 
                 BuyDate = DateTime.Parse(collection["BuyDate"]),
                Color   = (Color)Enum.Parse(typeof(Color),  collection["Color"]),
               ImageFilename  = collection["ImageFilename"]  ,
                Price = Decimal.Parse(collection["Price"])  ,
                    InventoryQuantity = Int32.Parse(collection["InventoryQuantity"] )
                };

                productRepository.CreateEntity(product);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductsController/Edit/5
        public ActionResult Edit(int id)
        {
            Product product = productRepository.RetreiveEntity(id).ReturnData;
            return View(product);
        }

        // POST: ProductsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Product product)
        {
            try
            {
                productRepository.UpdateEntity(product, id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductsController/Delete/5
        public ActionResult Delete(int id)
        {

            Product product = productRepository.RetreiveEntity(id).ReturnData;

            return View(product);
        }

        // POST: ProductsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                productRepository.HardDeleteEntity(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }



        // GET: BasketController
        public ActionResult AddProduct()
        {
            return View();
        }


        // Post: BasketController
        [HttpPost]
        public ActionResult AddProduct(ProductWithImage productWithImage)
        {
            try
            {
                Product product = productWithImage.Product;



                var img = productWithImage.ProductImage;


                // do other validations on your model as needed
                if (img != null)
                {
                    var uniqueFileName = GetUniqueFileName(img.FileName);
                    var uploads = Path.Combine(hostEnvironment.ContentRootPath + "\\wwwroot", "uploads");
                    var filePath = Path.Combine(uploads, uniqueFileName);
                    img.CopyTo(new FileStream(filePath, FileMode.Create));

                    //to do : Save uniqueFileName  to your db table   
                    product.ImageFilename = "/uploads/"+uniqueFileName;

                    productRepository.CreateEntity(product);


                }


                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        private string GetUniqueFileName(string fileName)
        {
            fileName = Path.GetFileName(fileName);
            return Path.GetFileNameWithoutExtension(fileName)
                      + "_"
                      + Guid.NewGuid().ToString().Substring(0, 4)
                      + Path.GetExtension(fileName);
        }





    }
}
