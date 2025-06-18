using BankApi.Domain.DTOs;
using BankApi.Domain.Entities;
using BankApi.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BankApi.Infrastructure.Repository
{
    public class PaymentRepository(BankDbContext _context) : IPaymentRepository
    {
        public async Task CreateAsync(PaymentHistory entity, CancellationToken token)
        {
            await _context.PaymentHistories.AddAsync(entity, token);

            await _context.SaveChangesAsync(token);
        }

        public async Task<List<PaymentHistory>> GetAllAsync(CancellationToken token)
        {
            return await _context.PaymentHistories.ToListAsync(token);
        }

        public async Task<List<PaymentHistoryShowDto>> GetByBankRecordAsync(Guid id, CancellationToken token)
        {
            var item = await _context.PaymentHistories.Where(x => x.BankRecordId == id)
                .Select(x => new PaymentHistoryShowDto 
                {Name = x.Name, Date = x.Date, Status = x.Status, Total = x.Total })
                .ToListAsync(token);

            return item;
        }

        public async Task<PaymentHistory> GetByIdAsync(Guid id, CancellationToken token)
        {
            var item = await _context.PaymentHistories.FirstOrDefaultAsync(x => x.Id == id);

            return item;
        }

        public async Task RemoveAsync(Guid id, CancellationToken token)
        {
            await _context.PaymentHistories
                .Where(x => x.Id == id)
                .ExecuteDeleteAsync(token);

            await _context.SaveChangesAsync(token);
        }

        public async Task UpdateAsync(PaymentHistory entity, CancellationToken token)
        {
            _context.PaymentHistories.Update(entity);

            await _context.SaveChangesAsync(token);
        }
    }
}
