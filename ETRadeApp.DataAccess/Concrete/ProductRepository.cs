using ETRadeApp.Core.DataAccess.EntityFramework;
using ETRadeApp.DataAccess.Abstract;
using ETRadeApp.DataAccess.Context;
using ETRadeApp.Entities;

namespace ETRadeApp.DataAccess.Concrete
{
    public class ProductRepository : EfRepositoryBase<Product, int, MsSqlDbContext>, IProductRepository
    {
        public ProductRepository(MsSqlDbContext context) : base(context)
        {
        }
    }
}
