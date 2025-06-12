using BankApi.Domain;
using BankApi.Domain.DTOs;
using BankApi.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BankApi.Infrastructure.Repository
{
    public class ClientRepository(BankDbContext _context) : IClientRepository
    {
        public async Task CreateClientAsync(Client client, CancellationToken token)
        {
            await _context.Clients.AddAsync(client, token);

            await _context.SaveChangesAsync(token);
        }

        public async Task<List<BankCardDto>> GetAllBankCardsAsync(Guid bankRecordId, CancellationToken token)
        {
            return await _context.BankCards
                .Where(x => x.BankRecordId == bankRecordId)
                .Select(x => new BankCardDto { CardNumber = x.CardNumber, CvvCode = x.CvvCode, Date = x.Date })
                .AsNoTracking()
                .ToListAsync(token);
        }

        public async Task<List<BankRecordDto>> GetAllBankRecordsAsync(Guid clientId, CancellationToken token)
        {
            return await _context.BankRecords
                .Where(x => x.ClientId == clientId)
                .Select(x => new BankRecordDto { Id = x.Id, Total = x.Total})
                .AsNoTracking()
                .ToListAsync(token);
        }
    }
}
