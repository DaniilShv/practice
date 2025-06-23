using BankApi.Domain.DTOs;
using BankApi.Domain.Entities;

namespace BankApi.Service.Interfaces
{
    public interface IBankBranchService
    {
        Task CreateBankBranchAsync(BankBranchCreateDto dto, CancellationToken token);

        Task<List<BankBranch>> GetAllAsync(CancellationToken token);
    }
}
