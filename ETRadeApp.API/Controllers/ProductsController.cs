using ETRadeApp.Business.Abstract;
using ETRadeApp.Business.Dtos.Product;
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
        public IActionResult AddAsync([FromBody] RequestProductAddDto request)
        {
            var product =  _productService.AddAsync(request);
            return Ok(product);
        }
       
    }
}
