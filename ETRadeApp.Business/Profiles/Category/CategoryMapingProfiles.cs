using AutoMapper;
using ETRadeApp.Business.Dtos.Category;

namespace ETRadeApp.Business.Profiles.Category
{
    internal class CategoryMapingProfiles:Profile
    {
        public CategoryMapingProfiles()
        {
            CreateMap<ResponseCategoryListDto,Entities.Category>().ReverseMap();
            CreateMap<RequestCategoryDto, Entities.Category>().ReverseMap();
            CreateMap<ResponseCategoryAddDto, Entities.Category>().ReverseMap();
        }
    }
}
