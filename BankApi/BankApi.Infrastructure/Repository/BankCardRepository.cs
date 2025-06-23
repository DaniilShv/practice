using BankApi.Domain.DTOs;
using BankApi.Domain.Entities;
using BankApi.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BankApi.Infrastructure.Repository
{
    public class BankCardRepository(BankDbContext _context) : IBankCardRepository
    {
        /// <summary>
        /// Создать банковскую карту в БД
        /// </summary>
        /// <param name="entity">Экземпляр объекта</param>
        /// <param name="token">Cancellation token</param>
        public async Task CreateAsync(BankCard card, CancellationToken token)
        {
            await _context.BankCards.AddAsync(card, token);

            await _context.SaveChangesAsync(token);
        }

        /// <summary>
        /// Получить все банковские карты из БД
        /// </summary>
        /// <param name="token">Cancellation token</param>
        /// <returns>Список объектов</returns>
        public async Task<List<BankCard>> GetAllAsync(CancellationToken token)
        {
            return await _context.BankCards.ToListAsync(token);
        }

        /// <summary>
        /// Получить объект банковской карты по ID из БД
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <param name="token">Cancellation token</param>
        /// <returns>Экземпляр объекта</returns>
        public async Task<BankCard> GetByIdAsync(Guid id, CancellationToken token)
        {
            var item = await _context.BankCards.FirstOrDefaultAsync(x => x.Id == id, token);

            return item;
        }

        /// <summary>
        /// Метод реализующий оплату банковской картой
        /// </summary>
        /// <param name="cardDto">Экземпляр объекта BankCardPayDto</param>
        /// <param name="payment">Информация о платеже</param>
        /// <param name="token">Cancellation token</param>
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
            else
                throw new ArgumentNullException("Оформите банковскую карту");
        }

        /// <summary>
        /// Метод для удаления данных о банковской карте из БД по ID
        /// </summary>
        /// <param name="id">Идентификатор объекта</param>
        /// <param name="token">Cancellation token</param>
        public async Task RemoveAsync(Guid id, CancellationToken token)
        {
            await _context.BankCards
                .Where(x => x.Id == id)
                .ExecuteDeleteAsync(token);

            await _context.SaveChangesAsync(token);
        }

        /// <summary>
        /// Метод для обновления данных банковской карты в БД
        /// </summary>
        /// <param name="entity">Экземпляр объекта</param>
        /// <param name="token">Cancellation token</param>
        public async Task UpdateAsync(BankCard entity, CancellationToken token)
        {
            _context.BankCards.Update(entity);

            await _context.SaveChangesAsync(token);
        }
    }
}
