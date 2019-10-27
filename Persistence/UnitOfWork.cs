using System.Threading.Tasks;
using CoffeeMug.Core;

namespace CoffeeMug.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ProductContext _context;
        public UnitOfWork(ProductContext context)
        {
            this._context = context;
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}