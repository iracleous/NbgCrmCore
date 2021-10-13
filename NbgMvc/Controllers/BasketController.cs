
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
    public class BasketController : Controller
    {

        private readonly IProductRepository productRepository;
        private readonly IHostEnvironment hostEnvironment;

        public BasketController(IProductRepository _productRepository, IHostEnvironment environment)
        {
            productRepository = _productRepository;
            hostEnvironment = environment;
        }


        public ActionResult Index2()
        {
            return View();
        }



        // GET: BasketController
        public ActionResult Index()
        {
            return View("Basket", null);
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
                    var uploads = Path.Combine(hostEnvironment.ContentRootPath+"\\wwwroot", "uploads");
                    var filePath = Path.Combine(uploads, uniqueFileName);
                    img.CopyTo(new FileStream(filePath, FileMode.Create));

                    //to do : Save uniqueFileName  to your db table   
                    product.ImageFilename = uniqueFileName;

                   productRepository.CreateEntity(product);


                }


                return RedirectToAction(nameof(Index2));
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

        // GET: BasketController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BasketController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BasketController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BasketController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BasketController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BasketController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BasketController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
