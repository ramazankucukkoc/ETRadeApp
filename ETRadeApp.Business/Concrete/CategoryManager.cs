using AutoMapper;
using ETRadeApp.Business.Abstract;
using ETRadeApp.Business.Dtos.Category;
using ETRadeApp.DataAccess.Abstract;
using ETRadeApp.Entities;

namespace ETRadeApp.Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;
        public CategoryManager(IMapper mapper, ICategoryRepository categoryRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }
        public async Task<ResponseCategoryAddDto> AddAsync(RequestCategoryDto category)
        {
            var mappedCategory = _mapper.Map<Category>(category);
            var addedCategory = await _categoryRepository.AddAsync(mappedCategory);
            var mappedAddedCategory=_mapper.Map<ResponseCategoryAddDto>(addedCategory);
            return mappedAddedCategory;
        }       
    }
}
