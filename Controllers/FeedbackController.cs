using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace VicStarDevPortfolio.Controllers
{
    [Route("Feedback")]
    public class FeedbackController : Controller
    {
        // GET: /Feedback
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        // POST: /Feedback/SaveHeart
        [HttpPost("SaveHeart")]
        public IActionResult SaveHeart([FromBody] EmojiFeedbackModel model)
        {
            if (model != null && !string.IsNullOrWhiteSpace(model.Emoji))
            {
                // TODO: Save emoji to DB or log
                // Example: _context.EmojiFeedbacks.Add(new EmojiFeedback { Value = model.Emoji });
                //          _context.SaveChanges();

                return Ok(new { success = true, message = "Feedback saved." });
            }

            return BadRequest(new { success = false, message = "Invalid data." });
        }

        //[HttpGet("List")]
        //public IActionResult List()
        //{
        //    var feedbacks = _context.EmojiFeedbacks.OrderByDescending(f => f.SubmittedAt).ToList();
        //    return View(feedbacks);
        //}

    }

    // Can also move this class to a separate file in the Models folder
    public class EmojiFeedbackModel
    {
        public string Emoji { get; set; }
    }
}
