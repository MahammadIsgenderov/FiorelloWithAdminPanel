using FiorelloAdminPanel.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace FiorelloAdminPanel.DAL
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
    }
}
