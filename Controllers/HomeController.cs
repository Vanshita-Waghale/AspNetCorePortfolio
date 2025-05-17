using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using VicStarDevPortfolio.Models;
using Microsoft.Extensions.Logging;
namespace VicStarDevPortfolio.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        //[HttpGet]
        //public IActionResult Contact()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult Contact(string name, string email, string message)
        //{
        //    // In a real app, you'd save this or send an email
        //    ViewBag.Message = "Thank you for contacting me!";
        //    return View();
        //}
        // HomeController.cs
        [HttpGet]
        public IActionResult Contact()
        {
            ViewBag.ShowCard = TempData["ShowCard"] != null && (bool)TempData["ShowCard"];
            return View(new Contact());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}

        public IActionResult Projects()
        {
            return View();
        }


    }
}
