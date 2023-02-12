using Microsoft.EntityFrameworkCore;
using VkusProekt.Data.Models;

namespace VkusProekt.Data
{
    public class AppDBContent : DbContext
    {
        public AppDBContent(DbContextOptions<AppDBContent> options) : base(options) { }

        public DbSet <Bludo> Bludo { get; set; }
        public DbSet<Category> Category { get; set; }
    }
}
