using BankApi.Domain.DTOs;
using BankApi.Domain.Entities;
using BankApi.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BankApi.Infrastructure.Repository
{
    public class ClientCreditRepository(BankDbContext _context) : IClientCreditRepository
    {
        /// <summary>
        /// Создать объект кредита в БД
        /// </summary>
        /// <param name="entity">Экземпляр объекта</param>
        /// <param name="token">Cancellation token</param>
        public async Task CreateAsync(ClientCredit entity, CancellationToken token)
        {
            await _context.ClientCredits.AddAsync(entity, token);

            await _context.SaveChangesAsync(token);
        }

        /// <summary>
        /// Получить информацию о всех кредитах из БД
        /// </summary>
        /// <param name="token">Cancellation token</param>
        /// <returns>Список объектов</returns>
        public async Task<List<ClientCredit>> GetAllAsync(CancellationToken token)
        {
            return await _context.ClientCredits.ToListAsync(token);
        }

        /// <summary>
        /// Получить информацию о кредите по ID из БД
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <param name="token">Cancellation token</param>
        /// <returns>Экземпляр объекта</returns>
        public async Task<ClientCredit> GetByIdAsync(Guid clientId, Guid creditId, CancellationToken token)
        {
            var item = await _context.ClientCredits
                .FirstOrDefaultAsync(x => x.ClientId == clientId 
                && x.CreditId == creditId, token);

            return item;
        }

        /// <summary>
        /// Метод для удаления данных о кредите из БД по ID
        /// </summary>
        /// <param name="id">Идентификатор объекта</param>
        /// <param name="token">Cancellation token</param>
        public async Task RemoveAsync(Guid clientId, Guid creditId, CancellationToken token)
        {
            await _context.ClientCredits
                .Where(x => x.CreditId == creditId && x.ClientId == clientId)
                .ExecuteDeleteAsync(token);

            await _context.SaveChangesAsync(token);
        }

        /// <summary>
        /// Метод реализующий функцию положить деньги со счета на кредит
        /// </summary>
        /// <param name="dto">экземпляр объекта TransferMoneyCreditDto</param>
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
                throw new ArgumentNullException("Банковским счет с таким ID не найден в базе данных банка");
        }

        /// <summary>
        /// Метод для обновления данных о кредите в БД
        /// </summary>
        /// <param name="entity">Экземпляр объекта</param>
        /// <param name="token">Cancellation token</param>
        public async Task UpdateAsync(ClientCredit entity, CancellationToken token)
        {
            _context.ClientCredits.Update(entity);

            await _context.SaveChangesAsync(token);
        }
    }
}
