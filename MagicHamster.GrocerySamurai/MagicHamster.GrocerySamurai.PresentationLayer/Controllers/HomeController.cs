using System;
using System.Diagnostics;
using MagicHamster.GrocerySamurai.PresentationLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MagicHamster.GrocerySamurai.PresentationLayer.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public HomeController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public IActionResult Index()
        {
            if (signInManager.IsSignedIn(User))
            {
                setUserId();
            }
            else
            {
                clearUserId();
            }

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

        private void setUserId()
        {
            if (String.IsNullOrEmpty(HttpContext.Session.GetString("UserId")) && userManager.GetUserId(User) != null)
            {
                HttpContext.Session.SetString("UserId", userManager.GetUserId(User));
            }
        }

        private void clearUserId()
        {
            HttpContext.Session.SetString("UserId", "");
        }
    }
}
