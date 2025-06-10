using BankApi.Domain;

namespace BankApi.Infrastructure.Interfaces
{
    public interface IClientRepository
    {
        Task CreateClientAsync(Client client, CancellationToken token);
    }
}
