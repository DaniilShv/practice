using BankApi.Domain;
using BankApi.Domain.DTOs;
using BankApi.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BankApi.Infrastructure.Repository
{
    internal class BankCardRepository(BankDbContext _context) : IBankCardRepository
    {
        public async Task CreateBankCardAsync(BankCard card, CancellationToken token)
        {
            await _context.BankCards.AddAsync(card, token);

            await _context.SaveChangesAsync(token);
        }

        public async Task PayCardAsync(PayCardDto cardDto, PaymentHistory payment,
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
    }
}
