using AutoMapper;
using BankApi.Domain.DTOs;
using BankApi.Domain.Entities;

namespace BankApi.Service.MappingProfiles
{
    public class BankEmployeeProfile : Profile
    {
        public BankEmployeeProfile()
        {
            CreateMap<Employee, EmployeeShowDto>().ReverseMap();
            CreateMap<Employee, CreateEmployeeDto>().ReverseMap();
        }
    }
}
