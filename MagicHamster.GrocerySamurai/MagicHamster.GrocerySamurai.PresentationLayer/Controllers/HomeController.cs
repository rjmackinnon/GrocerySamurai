﻿using System.Diagnostics;
using MagicHamster.GrocerySamurai.PresentationLayer.Models;
using Microsoft.AspNetCore.Mvc;

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
