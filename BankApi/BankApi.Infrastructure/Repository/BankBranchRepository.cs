using BankApi.Domain.Entities;
using BankApi.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BankApi.Infrastructure.Repository
{
    public class BankBranchRepository(BankDbContext _context) : IBankBranchRepository
    {

        public async Task CreateAsync(BankBranch bankBranch, CancellationToken token)
        {
            await _context.BankBranches.AddAsync(bankBranch, token);

            await _context.SaveChangesAsync(token);
        }

        public async Task<List<BankBranch>> GetAllAsync(CancellationToken token)
        {
            return await _context.BankBranches.ToListAsync(token);
        }

        public async Task<BankBranch> GetById(BankBranch entity, CancellationToken token)
        {
            return await _context.BankBranches.FirstOrDefaultAsync(x => x.Id == entity.Id, token);
        }

        public async Task RemoveAsync(BankBranch entity, CancellationToken token)
        {
            _context.BankBranches.Remove(entity);

            await _context.SaveChangesAsync(token);
        }

        public async Task UpdateAsync(BankBranch entity, CancellationToken token)
        {
            _context.BankBranches.Update(entity);

            await _context.SaveChangesAsync(token);
        }
    }
}
