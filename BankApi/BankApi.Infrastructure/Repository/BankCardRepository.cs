using BankApi.Domain;
using BankApi.Infrastructure.Interfaces;

namespace BankApi.Infrastructure.Repository
{
    internal class BankCardRepository(BankDbContext _context) : IBankCardRepository
    {
        public async Task CreateBankCardAsync(BankCard card, CancellationToken token)
        {
            await _context.BankCards.AddAsync(card, token);

            await _context.SaveChangesAsync(token);
        }
    }
}
