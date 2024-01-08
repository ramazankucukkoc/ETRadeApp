using ETRadeApp.API.Dtos;
using ETRadeApp.Business.Abstract;
using ETRadeApp.Entities;
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
        public IActionResult Add([FromBody] CategoryAddDto categoryAddDto)
        {
            Category category = new Category();
            category.CreatedDate = DateTime.Now;
            category.Name = categoryAddDto.Name;
            _categoryService.Add(category);
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> ConsumerAdd()
        {
           await _categoryService.ConsumerAdd();
            return Ok();
        }
    }
}
