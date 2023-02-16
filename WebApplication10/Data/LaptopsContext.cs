using Microsoft.EntityFrameworkCore;
using WebApplication10.Models;
using System.Collections.Generic;
using WebApplication10.Models;

namespace WebApplication10.Data
{
    public class LaptopsContext : DbContext
    {
        public DbSet<Laptop> Laptops { get; set; } = null!;
        public DbSet<Brand> Brands { get; set; } = null!;
        public LaptopsContext(DbContextOptions<LaptopsContext> options) : base(options) { }

        public LaptopsContext() { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=localhost\SQLEXPRESS;Database=LaptopsDb;Integrated Security=false;User ID=sa;Password=1234;TrustServerCertificate=true");
        }
    }
}