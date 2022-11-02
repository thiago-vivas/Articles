using Application.Models;
using AutoMapper;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Profiles
{
    public class CategoryProfile:Profile
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
