using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MagicHamster.GrocerySamurai.PresentationLayer.Models;

namespace MagicHamster.GrocerySamurai.PresentationLayer.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Grocery Samurai";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Contact the good folks at MagicHamster.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
