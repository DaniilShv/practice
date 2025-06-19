using BankApi.Domain.DTOs;

namespace BankApi.Service.Interfaces
{
    public interface IBankCardService
    {
        /// <summary>
        /// Создает экземпляр BankCard и делает асинхронный запрос к repository
        /// </summary>
        /// <param name="bankRecordId">ID банковского счета, на который ссылается карта</param>
        /// <param name="token">Cancellation token</param>
        Task CreateBankCardAsync(Guid bankRecordId, CancellationToken token);

        /// <summary>
        /// Делает асинхронный запрос с информацией о покупке с карты к repository
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="nameSeller">Название получателя платежа</param>
        /// <param name="token">Cancellation token</param>
        Task PayCardAsync(BankCardPayDto dto, string nameSeller, CancellationToken token);
    }
}
