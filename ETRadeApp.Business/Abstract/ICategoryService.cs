using ETRadeApp.Business.Dtos.Category;
using ETRadeApp.Entities;

namespace ETRadeApp.Business.Abstract
{
    public interface ICategoryService
    {
        Task<ResponseCategoryAddDto> AddAsync(RequestCategoryDto category);
    }
}
