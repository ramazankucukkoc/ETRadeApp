using ETRadeApp.Business.Dtos.Bases;
using ETRadeApp.Business.Dtos.Product;
using ETRadeApp.Core.Bases;

namespace ETRadeApp.Business.Abstract
{
    public interface IProductService
    {
        Task<ResponseProductAddDto> AddAsync(RequestProductAddDto product);
        Task<PageListDto<ResponseProductListDto>> GetAllAsync(PageQuery query);
    }
}
