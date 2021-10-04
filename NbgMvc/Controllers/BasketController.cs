using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NbgMvc.Controllers
{
    public class BasketController : Controller
    {
        // GET: BasketController
        public ActionResult Index()
        {
            return View();
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
