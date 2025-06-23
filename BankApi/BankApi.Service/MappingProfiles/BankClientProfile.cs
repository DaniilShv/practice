using AutoMapper;
using BankApi.Domain.DTOs;
using BankApi.Domain.Entities;

namespace BankApi.Service.MappingProfiles
{
    public class BankClientProfile : Profile
    {
        public BankClientProfile()
        {
            CreateMap<Client, ClientShowDto>().ReverseMap();
            CreateMap<Client, ClientCreateDto>().ReverseMap();
        }
    }
}
