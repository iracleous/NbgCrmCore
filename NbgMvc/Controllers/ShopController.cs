using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NbgMvc.Controllers
{
    public class ShopController : Controller
    {
        // GET: ShopController
        public ActionResult Index()
        {
            return View();
        }

       
    }
}
