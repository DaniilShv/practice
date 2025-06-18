using AutoMapper;
using BankApi.Domain.DTOs;
using BankApi.Domain.Entities;

namespace BankApi.Service.MappingProfiles
{
    public class BankProfile : Profile
    {
        public BankProfile()
        {
            CreateMap<BankCard, BankCardShowDto>().ReverseMap();
            CreateMap<BankRecord, BankRecordDto>().ReverseMap();
            CreateMap<BankRecord, BankRecordCreateDto>().ReverseMap();
            CreateMap<Employee, EmployeeShowDto>().ReverseMap();
            CreateMap<Client, ClientShowDto>().ReverseMap();
            CreateMap<Client, ClientCreateDto>().ReverseMap();
            CreateMap<Client, ClientCreateDto>().ReverseMap();
            CreateMap<BankBranch, BankBranchCreateDto>().ReverseMap();
            CreateMap<ClientCredit, ClientCreditCreateDto>().ReverseMap();
            CreateMap<ClientCredit, ClientCreditRemoveDto>().ReverseMap();
            CreateMap<ClientDeposit, ClientDepositCreateDto>().ReverseMap();
        }
    }
}
