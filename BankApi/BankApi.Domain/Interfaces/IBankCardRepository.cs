using BankApi.Domain.DTOs;
using BankApi.Domain.Entities;

namespace BankApi.Domain.Interfaces
{
    public interface IBankCardRepository : IRepository<BankCard>
    {
        /// <summary>
        /// Метод реализующий оплату банковской картой
        /// </summary>
        /// <param name="cardDto">Экземпляр объекта BankCardPayDto</param>
        /// <param name="payment">Информация о платеже</param>
        /// <param name="token">Cancellation token</param>
        Task PayCardAsync(BankCardPayDto cardDto, PaymentHistory payment, CancellationToken token);
    }
}
