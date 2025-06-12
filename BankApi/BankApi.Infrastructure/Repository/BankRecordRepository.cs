using BankApi.Domain;
using BankApi.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BankApi.Infrastructure.Repository
{
    public class BankRecordRepository(BankDbContext _context) : IBankRecordRepository
    {
        public async Task CreateBankRecordAsync(BankRecord record, CancellationToken token)
        {
            await _context.AddAsync(record, token);

            await _context.SaveChangesAsync(token);
        }

        public async Task DepositMoneyOnRecord(BankRecord record, CancellationToken token)
        {
            var bankRecord = await _context.BankRecords.FirstOrDefaultAsync(x => x.Id == record.Id, token);

            if (bankRecord != null)
                bankRecord.Total = record.Total;

            _context.BankRecords.Update(bankRecord);

            await _context.SaveChangesAsync(token);
        }

        public async Task WithdrawalMoneyOnRecordAsync(Guid bankRecordId, decimal sum, CancellationToken token)
        {
            var bankRecord = await _context.BankRecords.FirstOrDefaultAsync(x => x.Id == bankRecordId, token);

            if (bankRecord != null)
                bankRecord.Total -= sum;

            _context.BankRecords.Update(bankRecord);

            await _context.SaveChangesAsync(token);
        }
    }
}
