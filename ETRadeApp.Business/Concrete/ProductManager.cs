using AutoMapper;
using ETRadeApp.Business.Abstract;
using ETRadeApp.Business.Dtos.Product;
using ETRadeApp.DataAccess.Abstract;
using ETRadeApp.Entities;

namespace ETRadeApp.Business.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductManager(IProductRepository productRepository, IMapper mapper)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }
        public async Task<ResponseProductAddDto> AddAsync(RequestProductAddDto product)
        {
            var mappedProduct = _mapper.Map<Product>(product);
            var addedProduct = await _productRepository.AddAsync(mappedProduct);
            var addedPorductMapped = _mapper.Map<ResponseProductAddDto>(addedProduct);
            return addedPorductMapped;
        }
    }
}
