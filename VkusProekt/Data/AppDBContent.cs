using Microsoft.EntityFrameworkCore;
using VkusProekt.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace VkusProekt.Data
{
    public class AppDBContent : DbContext
    {
        public AppDBContent(DbContextOptions<AppDBContent> options) : base(options) { }

        public DbSet <Bludo> Bludo { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet <ShopCartItem> ShopCartItem { get; set; }
    }
}
