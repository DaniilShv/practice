using AutoMapper;
using BankApi.Domain.DTOs;
using BankApi.Domain.Entities;

namespace BankApi.Service.MappingProfiles
{
    public class ClientCreditProfile : Profile
    {
        public ClientCreditProfile()
        {
            CreateMap<ClientCredit, ClientCreditCreateDto>().ReverseMap();
            CreateMap<ClientCredit, ClientCreditRemoveDto>().ReverseMap();
        }
    }
}
