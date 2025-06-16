using BankApi.Domain.DTOs;
using BankApi.Domain.Entities;
using BankApi.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BankApi.Infrastructure.Repository
{
    internal class BankCardRepository(BankDbContext _context) : IBankCardRepository
    {
        public async Task CreateAsync(BankCard card, CancellationToken token)
        {
            await _context.BankCards.AddAsync(card, token);

            await _context.SaveChangesAsync(token);
        }

        public async Task<List<BankCard>> GetAllAsync(CancellationToken token)
        {
            return await _context.BankCards.ToListAsync(token);
        }

        public async Task<BankCard> GetById(BankCard entity, CancellationToken token)
        {
            return await _context.BankCards.FirstOrDefaultAsync(x => x.Id == entity.Id, token);
        }

        public async Task PayCardAsync(BankCardPayDto cardDto, PaymentHistory payment,
            CancellationToken token)
        {
            var card = await _context.BankCards
                .FirstOrDefaultAsync(x => x.Id == cardDto.CardId, token);

            if (card != null)
            {
                var record = await _context.BankRecords
                    .FirstOrDefaultAsync(x => x.Id == card.BankRecordId);

                payment.BankRecordId = record.Id;

                if (record.Total >= cardDto.Sum)
                {
                    record.Total -= cardDto.Sum;

                    _context.BankRecords.Update(record);

                    await _context.PaymentHistories.AddAsync(payment);

                    await _context.SaveChangesAsync(token);
                }
            }
        }

        public async Task RemoveAsync(Guid id, CancellationToken token)
        {
            await _context.BankCards
                .Where(x => x.Id == id)
                .ExecuteDeleteAsync(token);

            await _context.SaveChangesAsync(token);
        }

        public async Task UpdateAsync(BankCard entity, CancellationToken token)
        {
            _context.BankCards.Update(entity);

            await _context.SaveChangesAsync(token);
        }
    }
}
