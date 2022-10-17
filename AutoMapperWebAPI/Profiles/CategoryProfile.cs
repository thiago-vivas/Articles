using AutoMapper;
using AutoMapperWebAPI.DTOs;
using AutoMapperWebAPI.Entities;

namespace AutoMapperWebAPI.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<CategoryDto, Category>()
                .ForMember(dest => dest.CategoryName,
                opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.CategoryId,
                opt => opt.Ignore());
            CreateMap<Category, CategoryDto>()
                .ForMember(dest => dest.Name,
                opt => opt.MapFrom(src => src.CategoryName));
        }
    }
}
