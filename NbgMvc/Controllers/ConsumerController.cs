using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NbgMvc.Controllers
{
    public class ConsumerController : Controller
    {
        // GET: ConsumerController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ConsumerController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ConsumerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ConsumerController/Create
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

        // GET: ConsumerController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ConsumerController/Edit/5
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

        // GET: ConsumerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ConsumerController/Delete/5
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
