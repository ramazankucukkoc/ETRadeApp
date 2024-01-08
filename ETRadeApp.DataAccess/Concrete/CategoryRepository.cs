using ETRadeApp.Core.DataAccess.Dapper;
using ETRadeApp.DataAccess.Abstract;
using ETRadeApp.Entities;
namespace ETRadeApp.DataAccess.Concrete
{
    public class CategoryRepository : DapperRepositoryBase<Category, int>, ICategoryRepository
    {      
    }
}
