using BankApi.Domain;
using BankApi.Infrastructure.Interfaces;

namespace BankApi.Infrastructure.Repository
{
    public class ClientDepositsRepository(BankDbContext _context) : IClientDepositsRepository
    {
        public async Task CreateDepositAsync(ClientDeposit deposit, CancellationToken token)
        {
            await _context.ClientDeposits.AddAsync(deposit, token);

            await _context.SaveChangesAsync(token);
        }
    }
}
