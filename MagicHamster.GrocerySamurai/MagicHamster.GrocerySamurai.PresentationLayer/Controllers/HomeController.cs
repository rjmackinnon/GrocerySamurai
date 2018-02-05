namespace MagicHamster.GrocerySamurai.PresentationLayer.Controllers
{
    using System;
    using System.Diagnostics;
    using MagicHamster.GrocerySamurai.PresentationLayer.Models;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public HomeController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            if (_signInManager.IsSignedIn(User))
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
            if (String.IsNullOrEmpty(HttpContext.Session.GetString("UserId")) && _userManager.GetUserId(User) != null)
            {
                HttpContext.Session.SetString("UserId", _userManager.GetUserId(User));
            }
        }

        private void clearUserId()
        {
            HttpContext.Session.SetString("UserId", string.Empty);
        }
    }
}
