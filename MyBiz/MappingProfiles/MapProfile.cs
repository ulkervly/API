using AutoMapper;
using MyBiz.Core.Models;
using MyBiz.DTOs;

namespace MyBiz.MappingProfiles
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<EmployeeCreateDto, Employee>().ReverseMap();
            CreateMap<EmployeeGetDto, Employee>().ReverseMap();
            CreateMap<EmployeeUpdateDto, Employee>().ReverseMap();
        }
    }
}
