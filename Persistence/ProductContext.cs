using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using CoffeeMug.Models;

namespace CoffeeMug.Persistence
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}