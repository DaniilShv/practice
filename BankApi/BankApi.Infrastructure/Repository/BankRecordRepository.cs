using BankApi.Domain.Entities;
using BankApi.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BankApi.Infrastructure.Repository
{
    public class BankRecordRepository(BankDbContext _context) : IBankRecordRepository
    {
        /// <summary>
        /// Создать объект банковского счета в БД
        /// </summary>
        /// <param name="entity">Экземпляр объекта</param>
        /// <param name="token">Cancellation token</param>   
        public async Task CreateAsync(BankRecord record, CancellationToken token)
        {
            await _context.AddAsync(record, token);

            await _context.SaveChangesAsync(token);
        }

        /// <summary>
        /// Метод реализующий функцию пополнения банковского счета
        /// </summary>
        /// <param name="record">экземпляр BankRecord</param>
        /// <param name="token">Cancellation Token</param>
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

        /// <summary>
        /// Получить все объекты банковского счета из БД
        /// </summary>
        /// <param name="token">Cancellation token</param>
        /// <returns>Список объектов</returns>
        public async Task<List<BankRecord>> GetAllAsync(CancellationToken token)
        {
            return await _context.BankRecords.ToListAsync(token);
        }

        /// <summary>
        /// Получить объект банковского счета по ID из БД
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <param name="token">Cancellation token</param>
        /// <returns>Экземпляр объекта</returns>
        public async Task<BankRecord> GetByIdAsync(Guid id, CancellationToken token)
        {
            var item = await _context.BankRecords.FirstOrDefaultAsync(x => x.Id == id, token);

            return item;
        }

        /// <summary>
        /// Метод для удаления банковского счета из БД по ID
        /// </summary>
        /// <param name="id">Идентификатор объекта</param>
        /// <param name="token">Cancellation token</param>
        public async Task RemoveAsync(Guid id, CancellationToken token)
        {
            await _context.BankRecords
                .Where(x => x.Id == id)
                .ExecuteDeleteAsync(token);

            await _context.SaveChangesAsync(token);
        }

        /// <summary>
        /// Метод для обновления данных о банковском счете в БД
        /// </summary>
        /// <param name="entity">Экземпляр объекта</param>
        /// <param name="token">Cancellation token</param>
        public async Task UpdateAsync(BankRecord entity, CancellationToken token)
        {
            _context.BankRecords.Update(entity);

            await _context.SaveChangesAsync(token);
        }

        /// <summary>
        /// Метод реализующий функцию снятия денег из банковского счета
        /// </summary>
        /// <param name="bankRecordId">Идентификатор банковского счета</param>
        /// <param name="sum">Сумма</param>
        /// <param name="token">Cancellation Token</param>
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
