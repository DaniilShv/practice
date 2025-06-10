using BankApi.Domain;
using BankApi.Infrastructure.Interfaces;
using BankApi.Service.Interfaces;
using Identity.PasswordHasher;

namespace BankApi.Service
{
    public class ClientService(IClientRepository _clientRepository) : IClientService
    {

        public async Task CreateClientAsync(string surname, string name, string patronymic, ushort serialPassport, 
            uint numberPassport, string login, string password, CancellationToken token)
        {
            var hassher = new PasswordHasher();

            var client = new Client
            {
                Name = name,
                Patronymic = patronymic,
                Surname = surname,
                SerialPassport = serialPassport,
                NumberPassport = numberPassport,
                Login = login,
                PasswordHash = hassher.HashPassword(password)
            };

            await _clientRepository.CreateClientAsync(client, token);
        }
    }
}
