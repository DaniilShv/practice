using BankApi.Domain.DTOs;
using BankApi.Domain.Entities;

namespace BankApi.Service.Interfaces
{
    public interface IClientDepositsService
    {
        /// <summary>
        /// Создает запрос к repository об открытии вклада клиентом банка
        /// </summary>
        /// <param name="dto">Информация о клиенте и вкладе</param>
        /// <param name="token">Cancellation token</param>
        Task CreateDepositAsync(ClientDepositCreateDto dto, CancellationToken token);

        /// <summary>
        /// Информация о вкладах по дате начисления процентов
        /// </summary>
        /// <param name="date">Начисление процентов</param>
        /// <param name="token">Cancellation token</param>
        /// <returns>Список вкладов</returns>
        Task<List<ClientDeposit>> GetByDateAccuralAsync(DateTime date, CancellationToken token);

        /// <summary>
        /// Обновление информации о сумме вклада
        /// </summary>
        /// <param name="clientId">ID клиента</param>
        /// <param name="depositId">ID вклада</param>
        /// <param name="dt">Начисление процентов</param>
        /// <param name="total">Сумма</param>
        /// <param name="token">Cancellation token</param>
        Task UpdateTotalByKeyAsync(Guid clientId, Guid depositId, DateTime dt, decimal total, CancellationToken token);

        /// <summary>
        /// Создает запрос к repository о пополнении вклада клиентом банка
        /// </summary>
        /// <param name="dto">Информация о вкладе и банковском счете</param>
        /// <param name="token">Cancellation token</param>
        Task TransferMoneyOnDepositAsync(TransferMoneyDepositDto dto, CancellationToken token);

        /// <summary>
        /// Создает зпрос к repository о пополнении банковского счета со вклада
        /// </summary>
        /// <param name="dto">Информация о вкладе и банковском счете</param>
        /// <param name="token">Cancellation token</param>
        Task TransferMoneyFromDepositAsync(TransferMoneyDepositDto dto, CancellationToken token);
    }
}
