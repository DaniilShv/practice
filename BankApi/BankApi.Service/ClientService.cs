using AutoMapper;
using BankApi.Domain.DTOs;
using BankApi.Domain.Entities;
using BankApi.Domain.Interfaces;
using BankApi.Service.Interfaces;
using Identity.PasswordHasher;
using System.Data;
using System.Security.Claims;

namespace BankApi.Service
{
    public class ClientService(IClientRepository _clientRepository,
        IMapper _mapper) : IClientService
    {
        /// <summary>
        /// Создает запрос к repository на создание клиента банка
        /// </summary>
        /// <param name="dto">Информация о клиенте банка</param>
        public async Task CreateClientAsync(ClientCreateDto dto, CancellationToken token)
        {
            var hassher = new PasswordHasher();

            var client = _mapper.Map<Client>(dto);

            client.PasswordHash = hassher.HashPassword(dto.Password);

            await _clientRepository.CreateAsync(client, token);
        }

        /// <summary>
        /// Банковские карты клиента по ID банковского счета
        /// </summary>
        /// <param name="bankRecordId">ID банковского счета</param>
        /// <returns>Список банковских карт</returns>
        public async Task<List<BankCardShowDto>> GetAllBankCardsAsync(Guid bankRecordId, CancellationToken token)
        {
            var list = await _clientRepository.GetAllBankCardsAsync(bankRecordId, token);

            return list;
        }

        /// <summary>
        /// Банковские счета клиента по ID клиента
        /// </summary>
        /// <param name="clientId">ID клиента</param>
        /// <returns>Банковские счета клиента</returns>
        public async Task<List<BankRecordDto>> GetBankRecordsAsync(Guid clientId, CancellationToken token)
        {
            return await _clientRepository.GetAllBankRecordsAsync(clientId, token);
        }

        /// <summary>
        /// Проверка клиента в базе данных по логину и паролю
        /// </summary>
        /// <param name="dto">Логин и пароль</param>
        /// <returns>Клиент банка</returns>
        public async Task<ClientShowDto> LoginClientAsync(LoginDto dto, string refreshToken,
            CancellationToken token)
        {
            var hasher = new PasswordHasher();

            var client = await _clientRepository.LoginClientAsync(dto, token);

            client.RefreshToken = refreshToken;
            client.RefreshTokenExpiryTime = DateTime.UtcNow.AddYears(100);

            if (client != null)
            {
                if (hasher.VerifyHashedPassword(client.PasswordHash, dto.Password))
                {
                    await _clientRepository.UpdateAsync(client, token);

                    var clientShowDto = _mapper.Map<ClientShowDto>(client);

                    return clientShowDto;
                }
                else
                    throw new Exception("Введите верный пароль");
            }
            else
                throw new Exception("Пользователь с этим логином не найден в базе данных");
        }

        /// <summary>
        /// Получить сведения о клиенте банка
        /// </summary>
        /// <param name="client">Информация о клиенте</param>
        /// <returns>Сведения о клиенте банка</returns>
        public List<Claim> GetClaimClient(ClientShowDto client)
        {

            var claims = new List<Claim>();

            int age = GetAgeClient(client);

            if (age >= 18)
                claims.Add(new Claim("BankUserStatus", "ElderUser"));
            else
                claims.Add(new Claim("BankUserStatus", "AnyUser"));

            return claims;
        }

        int GetAgeClient(ClientShowDto client)
        {
            DateTime dt = client.DateBirth;
            DateTime current = DateTime.UtcNow;

            int age = current.Year - dt.Year;
            if (current.Month - dt.Month < 0)
                age--;
            else
                if (current.Day - dt.Day < 0)
                age--;

            return age;
        }

        /// <summary>
        /// Делает запрос к repository о клиенте банка по refresh token
        /// </summary>
        /// <returns>Клиент банка</returns>
        public async Task<Client> GetByRefreshTokenAsync(string refreshToken, CancellationToken token)
        {
            var client = await _clientRepository.GetByRefreshTokenAsync(refreshToken, token);

            if (client == null)
                throw new DataException("Пользователь с этим refresh Token не найден в базе данных");

            return client;
        }

        public async Task RemoveClientAsync(Guid id, CancellationToken token)
        {
            await _clientRepository.RemoveAsync(id, token);
        }
    }
}
