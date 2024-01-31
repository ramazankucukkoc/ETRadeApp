using ETRadeApp.Business.Dtos.Product;
using System.ServiceModel;

namespace ETRadeApp.Business.Abstract
{
    [ServiceContract]
    public interface IProductService
    {
        [OperationContract]
        Task<ResponseProductAddDto> AddAsync(RequestProductAddDto product);
    }
}
