using System;
using System.ComponentModel.DataAnnotations;

namespace VicStarDevPortfolio.Models
{
    public class Contact
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required]
        public string Message { get; set; }

        public DateTime SubmittedAt { get; set; } = DateTime.Now;

        // NEW field to store like emoji (❤️ or 🖤)
        public string LikeEmoji { get; set; }
    }
}
