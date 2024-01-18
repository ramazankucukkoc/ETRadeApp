using ETRadeApp.Business.Dtos.Product;

namespace ETRadeApp.Business.Abstract
{
    public interface IProductService
    {
       ResponseProductAddDto AddAsync(RequestProductAddDto product);
    }
}
