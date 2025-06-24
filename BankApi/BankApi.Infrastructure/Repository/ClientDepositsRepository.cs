using BankApi.Domain.DTOs;
using BankApi.Domain.Entities;
using BankApi.Domain.Interfaces;
using BankApi.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace BankApi.Infrastructure.Repository
{
    public class ClientDepositsRepository(BankDbContext _context) : IClientDepositsRepository
    {
        /// <summary>
        /// Создать объект вклада в БД
        /// </summary>
        /// <param name="entity">Экземпляр объекта</param>
        /// <param name="token">Cancellation token</param>
        public async Task CreateAsync(ClientDeposit deposit, CancellationToken token)
        {
            await _context.ClientDeposits.AddAsync(deposit, token);

            await _context.SaveChangesAsync(token);
        }

        /// <summary>
        /// Получить все объекты вклада из БД
        /// </summary>
        /// <param name="token">Cancellation token</param>
        /// <returns>Список объектов</returns>
        public async Task<List<ClientDeposit>> GetAllAsync(CancellationToken token)
        {
            return await _context.ClientDeposits.ToListAsync(token);
        }

        /// <summary>
        /// Информация о вкладе по дате начисления процентов
        /// </summary>
        /// <param name="date">Начисление процентов</param>
        /// <param name="token">Cancellation token</param>
        /// <returns>Список вкладов</returns>
        public async Task<List<ClientDeposit>> GetByDateAccuralAsync(DateTime date, CancellationToken token)
        {
            return await _context.ClientDeposits.Where(x => x.DateAccrualPercent.Date == date.Date)
                .ToListAsync(token);
        }

        /// <summary>
        /// Получить объект вклада по ID из БД
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <param name="token">Cancellation token</param>
        /// <returns>Экземпляр объекта</returns>
        public async Task<ClientDeposit> GetByIdAsync(Guid clientId, Guid depositId, CancellationToken token)
        {
            var item = await _context.ClientDeposits
                .FirstOrDefaultAsync(x => 
                x.ClientId == clientId && x.DepositId == depositId, token);

            if (item == null)
                throw new ArgumentNullException("Банковский вклад с таким ID не найден в базе данных банка");

            return item;
        }

        public DataTable GetDataTable()
        {
            return _context.ClientDeposits
                .Select(x => new
                {
                    ClientId = x.ClientId,
                    DepositId = x.DepositId,
                    Total = x.Total,
                    DateStart = x.DateStart,
                    DateAccrualPercent = x.DateAccrualPercent,
                    DateFinal = x.DateFinal,
                    Percent = x.Percent,
                    Type = x.Type
                })
                .ToDataTable();
        }

        public string GetTableName()
        {
            return "ClientDeposits";
        }

        /// <summary>
        /// Метод для удаления данных о вкладе по ID в БД
        /// </summary>
        /// <param name="id">Идентификатор объекта</param>
        /// <param name="token">Cancellation token</param>
        public async Task RemoveAsync(Guid clientId, Guid depositId, CancellationToken token)
        {
            await _context.ClientDeposits
                .Where(x => x.ClientId == clientId && x.DepositId == depositId)
                .ExecuteDeleteAsync(token);

            await _context.SaveChangesAsync(token);
        }

        /// <summary>
        /// Метод реализующий функцию положить деньги на счет со вклада
        /// </summary>
        /// <param name="dto">Экземпляр объекта TransferMoneyDepositDto</param>
        /// <param name="token"></param>
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
                throw new ArgumentNullException("Банковский вклад с таким ID не найден в базе данных банка");
        }

        /// <summary>
        /// Метод реализующий функцию положить деньги со счета на вклад
        /// </summary>
        /// <param name="dto">экземпляр объекта TransferMoneyDepositDto</param>
        /// <param name="token">Cancellation Token</param>
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
                throw new ArgumentNullException("Банковский счет с таким ID не найден в базе данных банка");
        }

        /// <summary>
        /// Метод для обновления данных о вкладе в БД
        /// </summary>
        /// <param name="entity">Экземпляр объекта</param>
        /// <param name="token">Cancellation token</param>
        public async Task UpdateAsync(ClientDeposit entity, CancellationToken token)
        {
            _context.ClientDeposits.Update(entity);

            await _context.SaveChangesAsync(token);
        }

        /// <summary>
        /// Обновить информацию о средствах на вкладе
        /// </summary>
        /// <param name="deposit"></param>
        /// <param name="token"></param>
        public async Task UpdateTotalByKeyAsync(ClientDeposit deposit, CancellationToken token)
        {
            var depositFromDb = await _context.ClientDeposits.FirstOrDefaultAsync(x =>
            x.ClientId == deposit.ClientId && x.DepositId == deposit.DepositId, token);

            if (depositFromDb != null)
                depositFromDb.Total = deposit.Total;
            else
                throw new ArgumentNullException("Банковский вклад с таким ID не найден в базе данных банка");

                _context.ClientDeposits.Update(depositFromDb);

            await _context.SaveChangesAsync(token);
        }
    }
}
