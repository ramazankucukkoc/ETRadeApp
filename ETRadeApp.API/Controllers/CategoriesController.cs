using ETRadeApp.Business.Abstract;
using ETRadeApp.Business.Dtos.Category;
using Microsoft.AspNetCore.Mvc;

namespace ETRadeApp.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] RequestCategoryDto categoryAddDto)
        {
            var result = await _categoryService.AddAsync(categoryAddDto);
            return Ok(result);
        }
    }
}
