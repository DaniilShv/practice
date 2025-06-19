using BankApi.Domain;
using BankApi.Domain.DTOs;
using BankApi.Domain.Entities;
using System.Security.Claims;

namespace BankApi.Service.Interfaces
{
    public interface IClientService
    {
        /// <summary>
        /// Создает запрос к repository на создание клиента банка
        /// </summary>
        /// <param name="dto">Информация о клиенте банка</param>
        Task CreateClientAsync(ClientCreateDto dto, CancellationToken token);

        /// <summary>
        /// Банковские счета клиента по ID клиента
        /// </summary>
        /// <param name="clientId">ID клиента</param>
        /// <returns>Банковские счета клиента</returns>
        Task<List<BankRecordDto>> GetBankRecordsAsync(Guid clientId, CancellationToken token);

        /// <summary>
        /// Банковские карты клиента по ID банковского счета
        /// </summary>
        /// <param name="bankRecordId">ID банковского счета</param>
        /// <returns>Список банковских карт</returns>
        Task<List<BankCardShowDto>> GetAllBankCardsAsync(Guid bankRecordId, CancellationToken token);

        /// <summary>
        /// Проверка клиента в базе данных по логину и паролю
        /// </summary>
        /// <param name="dto">Логин и пароль</param>
        /// <returns>Клиент банка</returns>
        Task<ClientShowDto> LoginClientAsync(LoginDto dto, string refreshToken, CancellationToken token);

        /// <summary>
        /// Получить сведения о клиенте банка
        /// </summary>
        /// <param name="client">Информация о клиенте</param>
        /// <returns>Сведения о клиенте банка</returns>
        List<Claim> GetClaimClient(ClientShowDto client);

        /// <summary>
        /// Делает запрос к repository о клиенте банка по refresh token
        /// </summary>
        /// <returns>Клиент банка</returns>
        Task<Client> GetByRefreshTokenAsync(string refreshToken, CancellationToken token);

        Task RemoveClientAsync(Guid id, CancellationToken token);
    }
}
