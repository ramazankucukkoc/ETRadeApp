using AutoMapper;
using ETRadeApp.Business.Dtos.Product;

namespace ETRadeApp.Business.Profiles.Product
{
    internal class ProductMappingProfiles : Profile
    {
        public ProductMappingProfiles()
        {
            CreateMap<RequestProductAddDto, ETRadeApp.Entities.Product>().ReverseMap();
            CreateMap<ResponseProductAddDto, ETRadeApp.Entities.Product>().ReverseMap();

        }
    }
}
