using System.Linq;
using Microsoft.AspNetCore.Mvc;
using VicStarDevPortfolio.Data;
using VicStarDevPortfolio.Models;

namespace VicStarDevPortfolio.Controllers
{
    [Route("Feedback")]
    public class FeedbackController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FeedbackController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("SaveHeart")]
        public IActionResult SaveHeart([FromBody] FeedbackDto data)
        {
            // Get the latest contact entry (most recent)
            var latestContact = _context.Contacts.OrderByDescending(c => c.SubmittedAt).FirstOrDefault();

            if (latestContact != null)
            {
                latestContact.LikeEmoji = data.Emoji;
                _context.SaveChanges();
            }

            return Ok(new { message = "Saved!" });
        }
    }

    public class FeedbackDto
    {
        public string Emoji { get; set; }
    }
}
