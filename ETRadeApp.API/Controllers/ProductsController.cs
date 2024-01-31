using ETRadeApp.Business.Abstract;
using ETRadeApp.Business.Dtos.Product;
using ETRadeApp.Business.Validator;
using Microsoft.AspNetCore.Mvc;

namespace ETRadeApp.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ILogger<ProductsController> _logger;
        public ProductsController(IProductService productService, ILogger<ProductsController> logger)
        {
            _productService = productService;
            _logger = logger;
        }

        [HttpPost]
        [FluentValidationAspect(typeof(RequestProductAddDtoValidator))]
        public async Task<IActionResult> AddAsync([FromBody] RequestProductAddDto request)
        {
            var product = await _productService.AddAsync(request);
            return Ok(product);
        }
    }
}