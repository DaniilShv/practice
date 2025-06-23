using AutoMapper;
using BankApi.Domain.DTOs;
using BankApi.Domain.Entities;

namespace BankApi.Service.MappingProfiles
{
    public class ClientDepositProfile : Profile
    {
        public ClientDepositProfile()
        {
            CreateMap<ClientDeposit, ClientDepositCreateDto>().ReverseMap();
        }
    }
}
