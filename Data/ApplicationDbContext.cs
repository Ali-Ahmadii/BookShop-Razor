using BookShop_Razor.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BookShop_Razor.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }

    }
}
