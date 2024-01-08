using ETRadeApp.Core.DataAccess;
using ETRadeApp.Entities;

namespace ETRadeApp.DataAccess.Abstract
{
    public interface ICategoryRepository : IAsyncRepository<Category, int>
    {

    }
}
