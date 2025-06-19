using BankApi.Domain.DTOs;
using BankApi.Domain.Entities;

namespace BankApi.Domain.Interfaces
{
    public interface IPaymentRepository : IRepository<PaymentHistory>
    {
        /// <summary>
        /// Информация обо всех платежах клиента (по ID банковского счета)
        /// </summary>
        /// <param name="id">ID банковского счета клиента</param>
        /// <param name="token">Cancellation token</param>
        /// <returns>Список платежей клиента</returns>
        Task<List<PaymentHistoryShowDto>> GetByBankRecordAsync(Guid id, CancellationToken token);
    }
}
