using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using VicStarDevPortfolio.Models;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using VicStarDevPortfolio.Data;

namespace VicStarDevPortfolio.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IActionResult Contact()
        {
            ViewBag.ShowCard = TempData["ShowCard"] != null && (bool)TempData["ShowCard"];
            return View(new Contact());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Contact(Contact model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            bool emailExists = _context.Contacts.Any(c => c.Email == model.Email);

            if (emailExists)
            {
                ModelState.AddModelError("Email", "This email is already used. Please enter another email.");
                return View(model);
            }

            _context.Contacts.Add(model);
            _context.SaveChanges();

            TempData["ShowCard"] = true;
            return RedirectToAction("Contact");
        }

        public IActionResult Index()
        {
            ViewBag.TotalVisitors = _context.Contacts.Count();
            ViewBag.TotalLikes = _context.Contacts.Count(c => c.LikeEmoji == "❤️");
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Projects()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
