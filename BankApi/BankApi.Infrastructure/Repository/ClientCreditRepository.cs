using BankApi.Domain.Entities;
using BankApi.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BankApi.Infrastructure.Repository
{
    public class ClientCreditRepository(BankDbContext _context) : IClientCreditRepository
    {
        public async Task CreateAsync(ClientCredit entity, CancellationToken token)
        {
            await _context.ClientCredits.AddAsync(entity, token);

            await _context.SaveChangesAsync(token);
        }

        public async Task<List<ClientCredit>> GetAllAsync(CancellationToken token)
        {
            return await _context.ClientCredits.ToListAsync(token);
        }

        public async Task<ClientCredit> GetByIdAsync(ClientCredit entity, CancellationToken token)
        {
            var item = await _context.ClientCredits
                .FirstOrDefaultAsync(x => x.ClientId == entity.ClientId 
                && x.CreditId == entity.CreditId, token);

            return item;
        }

        public async Task RemoveAsync(Guid clientId, Guid creditId, CancellationToken token)
        {
            await _context.ClientCredits
                .Where(x => x.CreditId == creditId && x.ClientId == clientId)
                .ExecuteDeleteAsync(token);

            await _context.SaveChangesAsync(token);
        }

        public async Task UpdateAsync(ClientCredit entity, CancellationToken token)
        {
            _context.ClientCredits.Update(entity);

            await _context.SaveChangesAsync(token);
        }
    }
}
