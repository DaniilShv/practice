using BankApi.Domain.DTOs;
using BankApi.Domain.Entities;

namespace BankApi.Domain.Interfaces
{
    public interface IClientDepositsRepository
    {
        /// <summary>
        /// Информация о вкладе по дате начисления процентов
        /// </summary>
        /// <param name="date">Начисление процентов</param>
        /// <param name="token">Cancellation token</param>
        /// <returns>Список вкладов</returns>
        Task<List<ClientDeposit>> GetByDateAccuralAsync(DateTime date, CancellationToken token);

        /// <summary>
        /// Обновить информацию о средствах на вкладе
        /// </summary>
        /// <param name="deposit"></param>
        /// <param name="token"></param>
        Task UpdateTotalByKeyAsync(ClientDeposit deposit, CancellationToken token);

        /// <summary>
        /// Метод реализующий функцию положить деньги со счета на вклад
        /// </summary>
        /// <param name="dto">экземпляр объекта TransferMoneyDepositDto</param>
        /// <param name="token">Cancellation Token</param>
        Task TransferMoneyOnDeposit(TransferMoneyDepositDto dto, CancellationToken token);

        /// <summary>
        /// Метод реализующий функцию положить деньги на счет со вклада
        /// </summary>
        /// <param name="dto">Экземпляр объекта TransferMoneyDepositDto</param>
        /// <param name="token"></param>
        Task TransferMoneyFromDeposit(TransferMoneyDepositDto dto, CancellationToken token);

        /// <summary>
        /// Метод для получения информации о всех вкладах
        /// </summary>
        /// <param name="token">Cancellation token</param>
        /// <returns>Список всех вкладов</returns>
        Task<List<ClientDeposit>> GetAllAsync(CancellationToken token);

        /// <summary>
        /// Метод для получения информации о вкладе по ID
        /// </summary>
        /// <param name="clientId">Идентификатор клиента</param>
        /// <param name="depositId">Идентификатор вклада</param>
        /// <param name="token">Cancellation token</param>
        /// <returns>Экземпляр объекта ClientDeposit</returns>
        Task<ClientDeposit> GetByIdAsync(Guid clientId, Guid depositId, CancellationToken token);

        /// <summary>
        /// Создание записи о взятии вклада в БД
        /// </summary>
        /// <param name="deposit">Экземпляр объекта ClientDeposit</param>
        /// <param name="token">Cancellation token</param>
        Task CreateAsync(ClientDeposit entity, CancellationToken token);

        /// <summary>
        /// Метод для обновления данных объекта в БД
        /// </summary>
        /// <param name="entity">экземпляр объекта ClientDeposit</param>
        /// <param name="token">Cancellation token</param>
        Task UpdateAsync(ClientDeposit entity, CancellationToken token);

        /// <summary>
        /// Метод для удаления данных из БД по ID
        /// </summary>
        /// <param name="clientId">Идентификатор клиента</param>
        /// <param name="depositId">Идентификатор вклада</param>
        /// <param name="token">Cancellation token</param>
        Task RemoveAsync(Guid clientId, Guid depositId, CancellationToken token);
    }
}
