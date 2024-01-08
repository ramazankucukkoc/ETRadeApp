using AutoMapper;
using ETRadeApp.Business.Dtos.Bases;
using ETRadeApp.Business.Dtos.Product;
using ETRadeApp.Core.DataAccess;

namespace ETRadeApp.Business.Profiles.Product
{
    internal class ProductMappingProfiles : Profile
    {
        public ProductMappingProfiles()
        {
            CreateMap<RequestProductAddDto, Entities.Product>().ReverseMap();
            CreateMap<ResponseProductAddDto, Entities.Product>().ReverseMap();
            CreateMap<ResponseProductListDto, Entities.Product>().ReverseMap();
            CreateMap<PageListDto<ResponseProductListDto>, PagedResult<Entities.Product>>().ReverseMap();

        }
    }
}
