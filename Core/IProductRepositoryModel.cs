using System.Threading.Tasks;
using CoffeeMug.Models;

namespace CoffeeMug.Core
{
    public interface IProductRepositoryModel : IProductRepository
    {
                  Task<Product> GetProduct(ProductUpdateInputModel model);
    }
}