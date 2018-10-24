using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleServer.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Home page controller
        /// </summary>
        /// <returns>Empty view</returns>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary
        /// Summ controller
        /// </summary>
        /// <returns>Operation view with summ</returns>
        public IActionResult Summ(int? one, int? two)
        {
            if (one == null || two == null)
                ViewBag.Result = 0;
            else
                ViewBag.Result = one + two;

            return View("Operation"); 
        }
    }
}
