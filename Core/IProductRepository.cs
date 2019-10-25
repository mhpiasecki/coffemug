using CoffeeMug.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoffeeMug.Core
{
    public interface IProductRepository
    {
         Task<Product> GetProduct(Guid id);
         void Add(Product product);
         void Remove(Product product);
         Task<List<Product>> GetProducts();
    }
}