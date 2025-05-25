using Microsoft.AspNetCore.Mvc;
using VicStarDevPortfolio.Models;
using Microsoft.AspNetCore.Http;  // For Session and Cookies

namespace VicStarDevPortfolio.Controllers
{
    public class AdminController : Controller
    {
        // Hardcoded admin credentials (for demo only, consider using a secure store)
        private const string AdminUsername = "admin";
        private const string AdminPassword = "admin123";

        // GET: Admin/Login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // POST: Admin/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(AdminLoginViewModel model)
        {
            // Check if submitted form data is valid
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // Validate username and password
            if (model.Username == AdminUsername && model.Password == AdminPassword)
            {
                // Set session variable for admin logged-in state
                HttpContext.Session.SetString("IsAdmin", "true");

                // We have removed "Remember Me" cookie to avoid session persistence issues

                // Redirect to Contacts list page on successful login
                return RedirectToAction("List", "Contacts");
            }

            // If credentials are invalid, show error on login page
            TempData["Error"] = "Invalid admin credentials.";
            return View(model);
        }

        // GET: Admin/Logout
        public IActionResult Logout()
        {
            // Clear entire session on logout
            HttpContext.Session.Clear();

            // Remove any cookies if set (just in case)
            Response.Cookies.Delete("IsAdmin");

            // Redirect back to login page
            return RedirectToAction("Login");
        }
    }
}
