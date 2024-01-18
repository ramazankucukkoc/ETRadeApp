using ETRadeApp.Core.DataAccess.EntityFramework;
using ETRadeApp.DataAccess.Abstract;
using ETRadeApp.DataAccess.Contexts;
using ETRadeApp.Entities;
namespace ETRadeApp.DataAccess.Concrete
{
    public class CategoryRepository : EfRepositoryBase<Category, int, MsSqlDbContext>, ICategoryRepository
    {
        public CategoryRepository(MsSqlDbContext context) : base(context)
        {
        }
    }
}
