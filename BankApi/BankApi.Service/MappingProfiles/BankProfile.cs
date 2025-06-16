using AutoMapper;
using BankApi.Domain.DTOs;
using BankApi.Domain.Entities;

namespace BankApi.Service.MappingProfiles
{
    public class BankProfile : Profile
    {
        public BankProfile()
        {
            CreateMap<BankCard, BankCardShowDto>();
            CreateMap<BankRecord, BankRecordDto>();
            CreateMap<Employee, EmployeeShowDto>();
            CreateMap<Client, ClientShowDto>();
        }
    }
}
