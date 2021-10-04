using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NbgCrmCore.Model;
using NbgCrmCore.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NbgMvc.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductRepository productRepository;

        public ProductsController(IProductRepository _productRepository)
        {
            productRepository = _productRepository;
        }
        // GET: ProductsController
        public ActionResult Index()
        {
            List<Product> products = productRepository.RetreiveEntities(1,10).ToList();
            return View("List", products);
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
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
