using AutoMapper;
using BankApi.Domain.DTOs;
using BankApi.Domain.Entities;

namespace BankApi.Service.MappingProfiles
{
    public class BankCardProfile : Profile
    {
        public BankCardProfile()
        {
            CreateMap<BankCard, BankCardShowDto>().ReverseMap();
            CreateMap<BankCard, BankCardPayDto>().ReverseMap();
        }
    }
}
