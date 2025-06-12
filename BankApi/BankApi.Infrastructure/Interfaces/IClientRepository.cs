using BankApi.Domain;
using BankApi.Domain.DTOs;

namespace BankApi.Infrastructure.Interfaces
{
    public interface IClientRepository
    {
        Task CreateClientAsync(Client client, CancellationToken token);

        Task<List<BankRecordDto>> GetAllBankRecordsAsync(Guid clientId, CancellationToken token);

        Task<List<BankCardDto>> GetAllBankCardsAsync(Guid bankRecordId, CancellationToken token);
    }
}
