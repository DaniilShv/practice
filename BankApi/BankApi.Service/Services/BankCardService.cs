using BankApi.Domain.DTOs;
using BankApi.Domain.Entities;
using BankApi.Domain.Interfaces;
using BankApi.Service.Interfaces;

namespace BankApi.Service.Services
{
    public class BankCardService(IBankCardRepository _bankCardRepository) : IBankCardService
    {
        static Random rnd = new Random();

        /// <summary>
        /// Создает экземпляр BankCard и делает асинхронный запрос к repository
        /// </summary>
        /// <param name="bankRecordId">ID банковского счета, на который ссылается карта</param>
        /// <param name="token">Cancellation token</param>
        public async Task CreateBankCardAsync(Guid bankRecordId, CancellationToken token)
        {
            var card = new BankCard
            {
                Date = DateTime.UtcNow,
                CardNumber = (ulong)rnd.NextInt64((long)Math.Pow(10,15), (long)Math.Pow(10, 16)),
                CvvCode = (ushort)rnd.Next(100, 1000),
                BankRecordId = bankRecordId
            };

            await _bankCardRepository.CreateAsync(card, token);
        }

        /// <summary>
        /// Получить все объекты сущности BankCard из базы данных
        /// </summary>
        /// <param name="token">Cancellation token</param>
        /// <returns>Список объектов BankCard</returns>
        public async Task<List<BankCard>> GetAllAsync(CancellationToken token)
        {
            return await _bankCardRepository.GetAllAsync(token);
        }

        /// <summary>
        /// Делает асинхронный запрос с информацией о покупке с карты к repository
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="nameSeller">Название получателя платежа</param>
        /// <param name="token">Cancellation token</param>
        public async Task PayCardAsync(BankCardPayDto dto, CancellationToken token)
        {
            var payment = new PaymentHistory
            {
                Name = dto.NameSeller,
                Date = DateTime.UtcNow,
                Total = dto.Sum
            };

            await _bankCardRepository.PayCardAsync(dto, payment, token);
        }
    }
}
