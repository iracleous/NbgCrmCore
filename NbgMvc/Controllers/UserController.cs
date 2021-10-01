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
    public class UserController : Controller
    {
        private readonly IUserRepository userRepository;


        public UserController(IUserRepository _userRepository) {
            userRepository = _userRepository;
        }

        // GET: UserController
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UserList()
        {
            List<User> users = userRepository.RetreiveEntities(1, 10).ToList();
            return View(users);
        }


        // GET: UserController/Details/5
        public ActionResult Details(int id)
        {
            User user = userRepository.RetreiveEntity(id).ReturnData;
            return View(user);
        }

        // GET: UserController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserController/Create
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

        // GET: UserController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserController/Edit/5
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

        // GET: UserController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserController/Delete/5
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
