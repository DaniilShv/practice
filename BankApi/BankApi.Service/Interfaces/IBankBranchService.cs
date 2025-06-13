using BankApi.Domain.DTOs;

namespace BankApi.Service.Interfaces
{
    public interface IBankBranchService
    {
        Task CreateBankBranchAsync(BankBranchCreateDto dto, CancellationToken token);
    }
}
