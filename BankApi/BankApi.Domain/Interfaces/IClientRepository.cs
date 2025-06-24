using BankApi.Domain.DTOs;
using BankApi.Domain.Entities;

namespace BankApi.Domain.Interfaces
{
    public interface IClientRepository : IRepository<Client>, IExcelRepository
    {
        Task<List<BankRecordDto>> GetAllBankRecordsAsync(Guid clientId, CancellationToken token);

        Task<List<BankCardShowDto>> GetAllBankCardsAsync(Guid bankRecordId, CancellationToken token);

        Task<Client> LoginClientAsync(LoginDto dto, CancellationToken token);

        Task<Client> GetByRefreshTokenAsync(string refreshToken, CancellationToken token);
    }
}
