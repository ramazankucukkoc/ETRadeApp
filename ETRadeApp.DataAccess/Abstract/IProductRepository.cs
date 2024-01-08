using ETRadeApp.Core.DataAccess;
using ETRadeApp.Entities;

namespace ETRadeApp.DataAccess.Abstract
{
    public interface IProductRepository : IAsyncRepository<Product, int>
    {

    }
}
