using BankApi.Domain.DTOs;
using BankApi.Domain.Entities;
using BankApi.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BankApi.Infrastructure.Repository
{
    public class PaymentRepository(BankDbContext _context) : IPaymentRepository
    {
        /// <summary>
        /// Создать объект платежа в БД
        /// </summary>
        /// <param name="entity">Экземпляр объекта</param>
        /// <param name="token">Cancellation token</param>
        public async Task CreateAsync(PaymentHistory entity, CancellationToken token)
        {
            await _context.PaymentHistories.AddAsync(entity, token);

            await _context.SaveChangesAsync(token);
        }

        /// <summary>
        /// Получить все платежи из БД
        /// </summary>
        /// <param name="token">Cancellation token</param>
        /// <returns>Список объектов</returns>
        public async Task<List<PaymentHistory>> GetAllAsync(CancellationToken token)
        {
            return await _context.PaymentHistories.ToListAsync(token);
        }

        /// <summary>
        /// Информация обо всех платежах клиента (по ID банковского счета)
        /// </summary>
        /// <param name="id">ID банковского счета клиента</param>
        /// <param name="token">Cancellation token</param>
        /// <returns>Список платежей клиента</returns>
        public async Task<List<PaymentHistoryShowDto>> GetByBankRecordAsync(Guid id, CancellationToken token)
        {
            var item = await _context.PaymentHistories.Where(x => x.BankRecordId == id)
                .Select(x => new PaymentHistoryShowDto 
                {Name = x.Name, Date = x.Date, Status = x.Status, Total = x.Total })
                .ToListAsync(token);

            return item;
        }

        /// <summary>
        /// Получить объект платежа по ID из БД
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <param name="token">Cancellation token</param>
        /// <returns>Экземпляр объекта</returns>
        public async Task<PaymentHistory> GetByIdAsync(Guid id, CancellationToken token)
        {
            var item = await _context.PaymentHistories.FirstOrDefaultAsync(x => x.Id == id);

            return item;
        }

        /// <summary>
        /// Метод для удаления данных о платеже из БД по ID
        /// </summary>
        /// <param name="id">Идентификатор объекта</param>
        /// <param name="token">Cancellation token</param>
        public async Task RemoveAsync(Guid id, CancellationToken token)
        {
            await _context.PaymentHistories
                .Where(x => x.Id == id)
                .ExecuteDeleteAsync(token);

            await _context.SaveChangesAsync(token);
        }

        /// <summary>
        /// Метод для обновления данных платежа в БД
        /// </summary>
        /// <param name="entity">Экземпляр объекта</param>
        /// <param name="token">Cancellation token</param>
        public async Task UpdateAsync(PaymentHistory entity, CancellationToken token)
        {
            _context.PaymentHistories.Update(entity);

            await _context.SaveChangesAsync(token);
        }
    }
}
