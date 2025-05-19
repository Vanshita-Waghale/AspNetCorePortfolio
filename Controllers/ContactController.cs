using System;
using System.Linq;
using System.Threading.Tasks;
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

        public IActionResult List()
        {
            var contacts = _context.Contacts.ToList();
            return View(contacts);
        }

        public IActionResult Details(int id)
        {
            var contact = _context.Contacts.FirstOrDefault(c => c.Id == id);
            return contact == null ? NotFound() : View(contact);
        }

        public IActionResult Edit(int id)
        {
            var contact = _context.Contacts.Find(id);
            return contact == null ? NotFound() : View(contact);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Contact contact)
        {
            if (!ModelState.IsValid) return View(contact);

            _context.Update(contact);
            _context.SaveChanges();
            TempData["Success"] = "Contact updated successfully!";
            return RedirectToAction(nameof(List));
        }

        // GET: Contact/Delete/5
        public IActionResult Delete(int id)
        {
            var contact = _context.Contacts.FirstOrDefault(c => c.Id == id);
            if (contact == null)
            {
                return NotFound();
            }
            return View(contact);
        }

        // POST: Contact/DeleteConfirmed/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var contact = _context.Contacts.Find(id);
            if (contact == null)
            {
                return NotFound();
            }

            _context.Contacts.Remove(contact);
            _context.SaveChanges();
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

            //[HttpPost]
            //public IActionResult SaveFeedback([FromBody] EmojiFeedback feedback)
            //{
            //    if (!string.IsNullOrWhiteSpace(feedback.Emoji))
            //    {
            //        // Log emoji feedback
            //        Console.WriteLine($"User emoji feedback: {feedback.Emoji}");
            //        return Ok();
            //    }
            //    return BadRequest();
            //}
        }

        //public class EmojiFeedback
        //{
        //    public string Emoji { get; set; }
        //}

}
