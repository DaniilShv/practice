using AutoMapper;
using BankApi.Domain.DTOs;
using BankApi.Domain.Entities;

namespace BankApi.Service.MappingProfiles
{
    public class BankRecordProfile : Profile
    {
        public BankRecordProfile()
        {
            CreateMap<BankRecord, BankRecordDto>().ReverseMap();
            CreateMap<BankRecord, BankRecordCreateDto>().ReverseMap();
        }
    }
}
