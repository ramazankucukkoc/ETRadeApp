using ETRadeApp.Business.Dtos.Product;
using ETRadeApp.Entities;

namespace ETRadeApp.Business.Abstract
{
    public interface IProductService
    {
        Task<ResponseProductAddDto> AddAsync(RequestProductAddDto product);

    }
}
