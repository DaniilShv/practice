using BankApi.Domain.DTOs;
using BankApi.Domain.Entities;
using BankApi.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BankApi.Infrastructure.Repository
{
    public class ClientRepository(BankDbContext _context) : IClientRepository
    {
        public async Task CreateAsync(Client client, CancellationToken token)
        {
            await _context.Clients.AddAsync(client, token);

            await _context.SaveChangesAsync(token);
        }

        public async Task<List<Client>> GetAllAsync(CancellationToken token)
        {
            return await _context.Clients.ToListAsync(token);
        }

        public async Task<List<BankCardShowDto>> GetAllBankCardsAsync(Guid bankRecordId, CancellationToken token)
        {
            return await _context.BankCards
                .Where(x => x.BankRecordId == bankRecordId)
                .Select(x => new BankCardShowDto { CardNumber = x.CardNumber, CvvCode = x.CvvCode, Date = x.Date })
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

        public async Task<Client> GetById(Client entity, CancellationToken token)
        {
            var client = await _context.Clients.FirstOrDefaultAsync(x => x.Id == entity.Id, token);

            return client;
        }

        public async Task<Client> GetByRefreshTokenAsync(string refreshToken, CancellationToken token)
        {
            return await _context.Clients.FirstOrDefaultAsync(x => x.RefreshToken == refreshToken);
        }

        public async Task<Client> LoginClientAsync(LoginDto dto, CancellationToken token)
        {
            var client = await _context.Clients.FirstOrDefaultAsync(x => x.Login == dto.Login);

            return client;
        }

        public async Task RemoveAsync(Client entity, CancellationToken token)
        {
            _context.Clients.Remove(entity);

            await _context.SaveChangesAsync(token);
        }

        public async Task UpdateAsync(Client entity, CancellationToken token)
        {
            _context.Clients.Update(entity);

            await _context.SaveChangesAsync(token);
        }
    }
}
