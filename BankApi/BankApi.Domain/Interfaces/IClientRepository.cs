using BankApi.Domain.DTOs;
using BankApi.Domain.Entities;

namespace BankApi.Domain.Interfaces
{
    public interface IClientRepository : IRepository<Client>
    {
        /// <summary>
        /// Информация обо всех банковских счетах клиента
        /// </summary>
        /// <param name="clientId">ID клиента банка</param>
        /// <param name="token">Cancellation token</param>
        /// <returns>Список банковских счетов клиента</returns>
        Task<List<BankRecordDto>> GetAllBankRecordsAsync(Guid clientId, CancellationToken token);

        /// <summary>
        /// Информация обо всех банковских картах клиента (по ID банковского счета)
        /// </summary>
        /// <param name="bankRecordId">ID банковского счета</param>
        /// <param name="token">Cancellation token</param>
        /// <returns>Список банковских карт клиента</returns>
        Task<List<BankCardShowDto>> GetAllBankCardsAsync(Guid bankRecordId, CancellationToken token);

        /// <summary>
        /// Информация о клиенте по логину
        /// </summary>
        /// <param name="dto">Экземпляр LoginDto</param>
        /// <param name="token">Cancellation token</param>
        /// <returns>экземпляр Client</returns>
        Task<Client> LoginClientAsync(LoginDto dto, CancellationToken token);

        /// <summary>
        /// Информация о клиенте по refresh token
        /// </summary>
        /// <param name="refreshToken">refresh token</param>
        /// <param name="token">Cancellation token</param>
        /// <returns>Экземпляр CLient</returns>
        Task<Client> GetByRefreshTokenAsync(string refreshToken, CancellationToken token);
    }
}
