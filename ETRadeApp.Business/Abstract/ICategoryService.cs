using ETRadeApp.Entities;

namespace ETRadeApp.Business.Abstract
{
    public interface ICategoryService
    {
        void Add(Category category);
        Task ConsumerAdd();

    }
}
