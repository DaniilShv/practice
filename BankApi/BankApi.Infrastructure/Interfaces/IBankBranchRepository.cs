using BankApi.Domain;

namespace BankApi.Infrastructure.Interfaces
{
    public interface IBankBranchRepository
    {
        Task CreateBankBranchAsync(BankBranch bankBranch, CancellationToken token);
    }
}
