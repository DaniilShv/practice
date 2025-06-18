using AutoMapper;
using BankApi.Domain.DTOs;
using BankApi.Domain.Entities;
using BankApi.Domain.Interfaces;
using BankApi.Service.Interfaces;

namespace BankApi.Service
{
    public class BankBranchService(IBankBranchRepository _bankBranchRepository,
        IMapper _mapper) : IBankBranchService
    {
        public async Task CreateBankBranchAsync(BankBranchCreateDto dto, CancellationToken token)
        {
            var bank = _mapper.Map<BankBranch>(dto);

            await _bankBranchRepository.CreateAsync(bank, token);
        }
    }
}
