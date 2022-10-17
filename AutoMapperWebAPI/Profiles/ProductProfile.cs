using AutoMapper;
using AutoMapperWebAPI.DTOs;
using AutoMapperWebAPI.Entities;

namespace AutoMapperWebAPI.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductDto, Product>()
                .ForMember(dest => dest.ProductName,
                opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.ProductId,
                opt => opt.Ignore());
            CreateMap<Product, ProductDto>()
                .ForMember(dest => dest.Name,
                opt => opt.MapFrom(src => src.ProductName));
        }
    }
}
