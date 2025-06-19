using BankApi.Domain.DTOs;
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

        public async Task<ClientCredit> GetByIdAsync(Guid clientId, Guid creditId, CancellationToken token)
        {
            var item = await _context.ClientCredits
                .FirstOrDefaultAsync(x => x.ClientId == clientId 
                && x.CreditId == creditId, token);

            return item;
        }

        public async Task RemoveAsync(Guid clientId, Guid creditId, CancellationToken token)
        {
            await _context.ClientCredits
                .Where(x => x.CreditId == creditId && x.ClientId == clientId)
                .ExecuteDeleteAsync(token);

            await _context.SaveChangesAsync(token);
        }

        public async Task TransferMoneyOnCredit(TransferMoneyCreditDto dto, CancellationToken token)
        {
            var record = await _context.BankRecords.FirstOrDefaultAsync(x => x.Id == dto.BankRecordId, token);

            if (record != null)
            {
                if (record.Total >= dto.Sum)
                {
                    var credit = await _context.ClientCredits.FirstOrDefaultAsync(x =>
                    x.ClientId == dto.ClientId && x.CreditId == dto.CreditId, token);

                    credit.Total -= dto.Sum;
                    record.Total -= dto.Sum;

                    _context.BankRecords.Update(record);
                    _context.ClientCredits.Update(credit);

                    await _context.SaveChangesAsync(token);
                }
                else
                    throw new Exception("На счете недостаточно средств");
            }
            else
                throw new ArgumentNullException("Банковский счет не существует");
        }

        public async Task UpdateAsync(ClientCredit entity, CancellationToken token)
        {
            _context.ClientCredits.Update(entity);

            await _context.SaveChangesAsync(token);
        }
    }
}
