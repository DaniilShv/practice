using BankApi.Domain.DTOs;
using BankApi.Domain.Entities;
using BankApi.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BankApi.Infrastructure.Repository
{
    public class ClientDepositsRepository(BankDbContext _context) : IClientDepositsRepository
    {
        public async Task CreateAsync(ClientDeposit deposit, CancellationToken token)
        {
            await _context.ClientDeposits.AddAsync(deposit, token);

            await _context.SaveChangesAsync(token);
        }

        public async Task<List<ClientDeposit>> GetAllAsync(CancellationToken token)
        {
            return await _context.ClientDeposits.ToListAsync(token);
        }

        public async Task<List<ClientDeposit>> GetByDateAccuralAsync(DateTime date, CancellationToken token)
        {
            return await _context.ClientDeposits.Where(x => x.DateAccrualPercent.Date == date.Date)
                .ToListAsync(token);
        }

        public async Task<ClientDeposit> GetById(ClientDeposit entity, CancellationToken token)
        {
            return await _context.ClientDeposits
                .FirstOrDefaultAsync(x => 
                x.ClientId == entity.ClientId && x.DepositId == entity.DepositId, token);
        }

        public async Task RemoveAsync(Guid clientId, Guid depositId, CancellationToken token)
        {
            await _context.ClientDeposits
                .Where(x => x.ClientId == clientId && x.DepositId == depositId)
                .ExecuteDeleteAsync(token);

            await _context.SaveChangesAsync(token);
        }

        public async Task TransferMoneyFromDeposit(TransferMoneyDepositDto dto, CancellationToken token)
        {
            var deposit = await _context.ClientDeposits.FirstOrDefaultAsync(x => 
            x.DepositId == dto.DepositId && x.ClientId == dto.ClientId, token);

            if (deposit != null)
            {
                if (deposit.Total >= dto.Sum)
                {
                    var record = await _context.BankRecords.FirstOrDefaultAsync(x =>
                    x.Id == dto.BankRecordId, token);

                    deposit.Total -= dto.Sum;
                    record.Total += dto.Sum;

                    _context.BankRecords.Update(record);
                    _context.ClientDeposits.Update(deposit);

                    await _context.SaveChangesAsync(token);
                }
                else
                    throw new Exception("На вкладе недостаточно средств");
            }
            else
                throw new ArgumentNullException("Банковский счет не существует");
        }

        public async Task TransferMoneyOnDeposit(TransferMoneyDepositDto dto, CancellationToken token)
        {
            var record = await _context.BankRecords.FirstOrDefaultAsync(x => x.Id == dto.BankRecordId, token);

            if (record != null)
            {
                if (record.Total >= dto.Sum)
                {
                    var deposit = await _context.ClientDeposits.FirstOrDefaultAsync(x =>
                    x.ClientId == dto.ClientId && x.DepositId == dto.DepositId, token);

                    deposit.Total += dto.Sum;
                    record.Total -= dto.Sum;

                    _context.BankRecords.Update(record);
                    _context.ClientDeposits.Update(deposit);

                    await _context.SaveChangesAsync(token);
                }
                else
                    throw new Exception("На счете недостаточно средств");
            }
            else
                throw new ArgumentNullException("Банковский счет не существует");
        }

        public async Task UpdateAsync(ClientDeposit entity, CancellationToken token)
        {
            _context.ClientDeposits.Update(entity);

            await _context.SaveChangesAsync(token);
        }

        public async Task UpdateTotalByKeyAsync(ClientDeposit deposit, CancellationToken token)
        {
            var depositFromDb = await _context.ClientDeposits.FirstOrDefaultAsync(x =>
            x.ClientId == deposit.ClientId && x.DepositId == deposit.DepositId, token);

            if (depositFromDb != null)
                depositFromDb.Total = deposit.Total;

            _context.ClientDeposits.Update(depositFromDb);

            await _context.SaveChangesAsync(token);
        }
    }
}
