using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CoffeeMug.Core;
using CoffeeMug.Models;
using Microsoft.EntityFrameworkCore;
namespace CoffeeMug.Persistence
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductContext _context;

        public ProductRepository(ProductContext context)
        {
            this._context = context;
        }

        public  void Add(Product product)
        {
           _context.Products.Add(product);
        }

        public async Task<Product> GetProduct(Guid id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<Product> GetProduct(ProductUpdateInputModel model)
        {
             return await _context.Products.FindAsync(model.Id);
        }

        public async Task<List<Product>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }

        public void Remove(Product product)
        {
           _context.Remove(product);
        }
    }
}