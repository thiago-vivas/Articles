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
    public class EmployeeProfile : Profile
    {

        public EmployeeProfile()
        {
            CreateMap<EmployeeDto, Employee>()
                    .ForMember(dest => dest.FirstName,
                    opt => opt.MapFrom(src => src.Name))
                    .ForMember(dest => dest.EmployeeId,
                    opt => opt.Ignore());
            CreateMap<Employee, EmployeeDto>()
                    .ForMember(dest => dest.Name,
                    opt => opt.MapFrom(src => src.FirstName));
        }
    }
}
