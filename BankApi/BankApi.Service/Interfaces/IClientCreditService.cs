using BankApi.Domain.DTOs;

namespace BankApi.Service.Interfaces
{
    public interface IClientCreditService
    {
        /// <summary>
        /// Создает запрос к repository о взятии кредита клиентом банка
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="token">Cancellation token</param>
        Task CreateCreditAsync(ClientCreditCreateDto dto, CancellationToken token);

        /// <summary>
        /// Создает запрос к repository о выплате кредита клиентом банка
        /// </summary>
        /// <param name="clientId">ID клиента</param>
        /// <param name="creditId">ID кредита</param>
        /// <param name="token">Cancellation token</param>
        Task RemoveCreditAsync(Guid clientId, Guid creditId, CancellationToken token);

        /// <summary>
        /// Создает запрос к repository о пополнении кредита клиентом банка
        /// </summary>
        /// <param name="dto">Информация о кредите и банковском счете</param>
        /// <param name="token">Cancellation token</param>
        Task TransferMoneyOnCreditAsync(TransferMoneyCreditDto dto, CancellationToken token);
    }
}
