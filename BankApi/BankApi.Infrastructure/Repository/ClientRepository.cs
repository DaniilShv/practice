using BankApi.Domain;
using BankApi.Infrastructure.Interfaces;

namespace BankApi.Infrastructure.Repository
{
    public class ClientRepository(BankDbContext _context) : IClientRepository
    {
        public async Task CreateClientAsync(Client client, CancellationToken token)
        {
            await _context.Clients.AddAsync(client, token);

            await _context.SaveChangesAsync(token);
        }
    }
}
