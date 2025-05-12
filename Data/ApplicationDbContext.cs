using Microsoft.EntityFrameworkCore;
using VicStarDevPortfolio.Models;

namespace VicStarDevPortfolio.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Contact> Contacts { get; set; }
    }
}
