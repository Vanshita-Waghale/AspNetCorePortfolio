using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VicStarDevPortfolio.Data;
using VicStarDevPortfolio.Models;

namespace VicStarDevPortfolio.Controllers
{
    public class ContactsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ContactsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Reusable admin check (based on session or cookie)
        private bool IsAdmin()
        {
            var session = HttpContext.Session.GetString("IsAdmin");
            var cookie = Request.Cookies["IsAdmin"];
            return session == "true" || cookie == "true";
        }

        public async Task<IActionResult> List()
        {
            if (!IsAdmin())
                return RedirectToAction("Login", "Admin");

            var contacts = await Task.Run(() => _context.Contacts.ToList());
            return View(contacts);
        }

        public async Task<IActionResult> Details(int id)
        {
            if (!IsAdmin())
                return RedirectToAction("Login", "Admin");

            var contact = await Task.Run(() => _context.Contacts.FirstOrDefault(c => c.Id == id));
            return contact == null ? NotFound() : View(contact);
        }

        public async Task<IActionResult> Edit(int id)
        {
            if (!IsAdmin())
                return RedirectToAction("Login", "Admin");

            var contact = await _context.Contacts.FindAsync(id);
            return contact == null ? NotFound() : View(contact);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Contact contact)
        {
            if (!IsAdmin())
                return RedirectToAction("Login", "Admin");

            if (!ModelState.IsValid)
                return View(contact);

            _context.Update(contact);
            await _context.SaveChangesAsync();

            TempData["Success"] = "Contact updated successfully!";
            return RedirectToAction(nameof(List));
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (!IsAdmin())
                return RedirectToAction("Login", "Admin");

            var contact = await Task.Run(() => _context.Contacts.FirstOrDefault(c => c.Id == id));
            return contact == null ? NotFound() : View(contact);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (!IsAdmin())
                return RedirectToAction("Login", "Admin");

            var contact = await _context.Contacts.FindAsync(id);
            if (contact == null)
                return NotFound();

            _context.Contacts.Remove(contact);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(List));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Submit(Contact contact)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Contact", "Home");

            _context.Contacts.Add(contact);
            await _context.SaveChangesAsync();

            TempData["ShowCard"] = true;
            return RedirectToAction("Contact", "Home");
        }
    }
}
