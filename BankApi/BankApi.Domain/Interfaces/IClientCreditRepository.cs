using BankApi.Domain.DTOs;
using BankApi.Domain.Entities;

namespace BankApi.Domain.Interfaces
{
    public interface IClientCreditRepository
    {
        /// <summary>
        /// Метод для получения информации о всех кредитах
        /// </summary>
        /// <param name="token">Cancellation token</param>
        /// <returns>Список всех кредитов</returns>
        Task<List<ClientCredit>> GetAllAsync(CancellationToken token);

        /// <summary>
        /// Метод для получения информации о кредите по ID
        /// </summary>
        /// <param name="clientId">Идентификатор клиента</param>
        /// <param name="creditId">Идентификатор кредита</param>
        /// <param name="token">Cancellation token</param>
        /// <returns>Экземпляр объекта ClientCredit</returns>
        Task<ClientCredit> GetByIdAsync(Guid clientId, Guid creditId, CancellationToken token);

        /// <summary>
        /// Создание записи о взятии кредита в БД
        /// </summary>
        /// <param name="entity">Экземпляр объекта ClientCredit</param>
        /// <param name="token">Cancellation token</param>
        Task CreateAsync(ClientCredit entity, CancellationToken token);

        /// <summary>
        /// Метод для обновления данных объекта в БД
        /// </summary>
        /// <param name="entity">экземпляр объекта ClientCredit</param>
        /// <param name="token">Cancellation token</param>
        Task UpdateAsync(ClientCredit entity, CancellationToken token);

        /// <summary>
        /// Метод для удаления данных из БД по ID
        /// </summary>
        /// <param name="clientId">Идентификатор клиента</param>
        /// <param name="creditId">Идентификатор кредита</param>
        /// <param name="token">Cancellation token</param>
        Task RemoveAsync(Guid clientId, Guid creditId, CancellationToken token);

        /// <summary>
        /// Метод реализующий функцию положить деньги со счета на кредит
        /// </summary>
        /// <param name="dto">экземпляр объекта TransferMoneyCreditDto</param>
        Task TransferMoneyOnCredit(TransferMoneyCreditDto dto, CancellationToken token);
    }
}
