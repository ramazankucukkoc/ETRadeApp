using ETRadeApp.Business.Abstract;
using ETRadeApp.Business.Dtos.Product;
using ETRadeApp.Core.Bases;
using Microsoft.AspNetCore.Mvc;

namespace ETRadeApp.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] RequestProductAddDto request)
        {
            var product = await _productService.AddAsync(request);
            return Ok(product);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PageQuery query)
        {
            var result = await _productService.GetAllAsync(query);
            return Ok(result);
        }
    }
}
