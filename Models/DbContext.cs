using Microsoft.EntityFrameworkCore;
using Tranning_pro.Models;

namespace Tranning_pro.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<City> Cities { get; set; }
    }
}