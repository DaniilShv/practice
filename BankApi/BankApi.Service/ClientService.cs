using BankApi.Domain.DTOs;
using BankApi.Domain.Entities;
using BankApi.Domain.Interfaces;
using BankApi.Service.Interfaces;
using Identity.PasswordHasher;
using System.Security.Claims;

namespace BankApi.Service
{
    public class ClientService(IClientRepository _clientRepository) : IClientService
    {

        public async Task CreateClientAsync(ClientCreateDto dto, CancellationToken token)
        {
            var hassher = new PasswordHasher();

            var client = new Client
            {
                Name = dto.Name,
                Patronymic = dto.Patronymic,
                Surname = dto.Surname,
                SerialPassport = dto.SerialPassport,
                NumberPassport = dto.NumberPassport,
                Login = dto.Login,
                PasswordHash = hassher.HashPassword(dto.Password)
            };

            await _clientRepository.CreateAsync(client, token);
        }

        public async Task<List<BankCardShowDto>> GetAllBankCardsAsync(Guid bankRecordId, CancellationToken token)
        {
            return await _clientRepository.GetAllBankCardsAsync(bankRecordId, token);
        }

        public async Task<List<BankRecordDto>> GetBankRecordsAsync(Guid clientId, CancellationToken token)
        {
            return await _clientRepository.GetAllBankRecordsAsync(clientId, token);
        }

        public async Task<ClientShowDto> LoginClientAsync(LoginDto dto, CancellationToken token)
        {
            var hasher = new PasswordHasher();

            var client = await _clientRepository.LoginClientAsync(dto, token);

            client.RefreshToken = dto.RefreshToken;
            client.RefreshTokenExpiryTime = DateTime.UtcNow.AddYears(100);

            if (client != null)
            {
                if (hasher.VerifyHashedPassword(client.PasswordHash, dto.Password))
                {
                    await _clientRepository.UpdateAsync(client, token);

                    return new ClientShowDto
                    {
                        Surname = client.Surname,
                        Name = client.Name,
                        Patronymic = client.Patronymic,
                        DateBirth = client.DateBirth,
                        NumberPassport = client.NumberPassport,
                        SerialPassport = client.SerialPassport
                    };
                }
                else
                    throw new Exception("Введите верный пароль");
            }
            else
                throw new Exception("Введите верный логин");
        }

        public List<Claim> GetClaimClient(ClientShowDto client)
        {

            var claims = new List<Claim>();

            int age = GetAgeClient(client);

            if (age >= 18)
                claims.Add(new Claim("ClientStatus", "ElderUser"));
            else
                claims.Add(new Claim("ClientStatus", "AnyUser"));

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

        public async Task<Client> GetByRefreshTokenAsync(string refreshToken, CancellationToken token)
        {
            return await _clientRepository.GetByRefreshTokenAsync(refreshToken, token);
        }
    }
}
