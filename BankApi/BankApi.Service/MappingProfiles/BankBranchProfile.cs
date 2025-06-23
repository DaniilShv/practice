using AutoMapper;
using BankApi.Domain.DTOs;
using BankApi.Domain.Entities;

namespace BankApi.Service.MappingProfiles
{
    public class BankBranchProfile : Profile
    {
        public BankBranchProfile()
        {
            CreateMap<BankBranch, BankBranchCreateDto>().ReverseMap();
        }
    }
}
