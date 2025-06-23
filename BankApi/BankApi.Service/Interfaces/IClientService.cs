using BankApi.Domain;
using BankApi.Domain.DTOs;
using BankApi.Domain.Entities;
using System.Security.Claims;

namespace BankApi.Service.Interfaces
{
    public interface IClientService
    {
        Task CreateClientAsync(ClientCreateDto dto, CancellationToken token);

        Task<List<BankRecordDto>> GetBankRecordsAsync(Guid clientId, CancellationToken token);

        Task<List<BankCardShowDto>> GetAllBankCardsAsync(Guid bankRecordId, CancellationToken token);

        Task<ClientShowDto> LoginClientAsync(LoginDto dto, string refreshToken, CancellationToken token);

        List<Claim> GetClaimClient(ClientShowDto client);

        Task<Client> GetByRefreshTokenAsync(string refreshToken, CancellationToken token);

        Task RemoveClientAsync(Guid id, CancellationToken token);

        Task<List<Client>> GetAllAsync(CancellationToken token);
    }
}
