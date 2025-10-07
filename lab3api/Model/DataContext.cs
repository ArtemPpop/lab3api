using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace lab3api.Model
{
    public class DataContext : DbContext
    {
        public DataContext()
        {
            //Database.EnsureCreated();
        }

        public DataContext(DbContextOptions<DataContext> options) : base(options) {
            //Database.EnsureCreated();
        }

        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<Sale> Sales { get; set; }
    }
}
