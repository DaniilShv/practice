using BankApi.Domain.DTOs;
using BankApi.Domain.Entities;
using BankApi.Domain.Interfaces;
using BankApi.Service.Interfaces;

namespace BankApi.Service
{
    public class BankBranchService(IBankBranchRepository _bankBranchRepository) : IBankBranchService
    {
        public async Task CreateBankBranchAsync(BankBranchCreateDto dto, CancellationToken token)
        {
            var bank = new BankBranch
            {
                LocationId = dto.LocationId,
                Adress = dto.Adress
            };

            await _bankBranchRepository.CreateAsync(bank, token);
        }
    }
}
