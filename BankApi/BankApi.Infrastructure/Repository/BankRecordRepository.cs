using BankApi.Domain.Entities;
using BankApi.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BankApi.Infrastructure.Repository
{
    public class BankRecordRepository(BankDbContext _context) : IBankRecordRepository
    {
        
        public async Task CreateAsync(BankRecord record, CancellationToken token)
        {
            await _context.AddAsync(record, token);

            await _context.SaveChangesAsync(token);
        }

        public async Task DepositMoneyOnRecord(BankRecord record, CancellationToken token)
        {
            var bankRecord = await _context.BankRecords.FirstOrDefaultAsync(x => x.Id == record.Id, token);

            if (bankRecord != null)
                bankRecord.Total = record.Total;
            else
                throw new ArgumentNullException("Введите корректно идентификатор банковского счета");

                _context.BankRecords.Update(bankRecord);

            await _context.SaveChangesAsync(token);
        }

        public async Task<List<BankRecord>> GetAllAsync(CancellationToken token)
        {
            return await _context.BankRecords.ToListAsync(token);
        }

        public async Task<BankRecord> GetByIdAsync(Guid id, CancellationToken token)
        {
            var item = await _context.BankRecords.FirstOrDefaultAsync(x => x.Id == id, token);

            return item;
        }

        public async Task RemoveAsync(Guid id, CancellationToken token)
        {
            await _context.BankRecords
                .Where(x => x.Id == id)
                .ExecuteDeleteAsync(token);

            await _context.SaveChangesAsync(token);
        }
        
        public async Task UpdateAsync(BankRecord entity, CancellationToken token)
        {
            _context.BankRecords.Update(entity);

            await _context.SaveChangesAsync(token);
        }

        public async Task WithdrawalMoneyOnRecordAsync(Guid bankRecordId, decimal sum, CancellationToken token)
        {
            var bankRecord = await _context.BankRecords.FirstOrDefaultAsync(x => x.Id == bankRecordId, token);

            if (bankRecord != null)
                bankRecord.Total -= sum;
            else
                throw new ArgumentNullException("Введите корректно идентификатор банковского счета");

                _context.BankRecords.Update(bankRecord);

            await _context.SaveChangesAsync(token);
        }
    }
}
