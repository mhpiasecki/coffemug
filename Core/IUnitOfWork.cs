using System.Threading.Tasks;

namespace CoffeeMug.Core
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}