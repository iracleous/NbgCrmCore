using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<UserController> logger;

        public UserController(IUserRepository _userRepository, ILogger<UserController> _logger) {
            userRepository = _userRepository;
            logger = _logger;
        }

        // GET: UserController
        public ActionResult Index()
        {
            logger.LogInformation("Index");
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
        public ActionResult Create([FromForm] User user)
        {
            try
            {
                userRepository.CreateEntity(user);

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
            User user = userRepository.RetreiveEntity(id).ReturnData;
            return View(user);
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [FromForm] User user)
        {
            try
            {
              userRepository.UpdateEntity(user, id);
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

            User user = userRepository.RetreiveEntity(id).ReturnData;
            return View(user);
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {

                bool success = userRepository.HardDeleteEntity(id);
                if (!success) throw new Exception("cannot delete");
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                User user = userRepository.RetreiveEntity(id).ReturnData;
                return View(user);
            }
        }
    }
}
