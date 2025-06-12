using BankApi.Domain;
using BankApi.Infrastructure.Interfaces;

namespace BankApi.Infrastructure.Repository
{
    public class BankBranchRepository(BankDbContext _context) : IBankBranchRepository
    {
        public async Task CreateBankBranchAsync(BankBranch bankBranch, CancellationToken token)
        {
            await _context.BankBranches.AddAsync(bankBranch, token);

            await _context.SaveChangesAsync(token);
        }
    }
}
