using BankApi.Domain.DTOs;
using BankApi.Domain.Entities;

namespace BankApi.Domain.Interfaces
{
    public interface IClientCreditRepository
    {
        Task<List<ClientCredit>> GetAllAsync(CancellationToken token);

        Task<ClientCredit> GetByIdAsync(Guid clientId, Guid creditId, CancellationToken token);

        Task CreateAsync(ClientCredit entity, CancellationToken token);

        Task UpdateAsync(ClientCredit entity, CancellationToken token);

        Task RemoveAsync(Guid clientId, Guid creditId, CancellationToken token);

        Task TransferMoneyOnCredit(TransferMoneyCreditDto dto, CancellationToken token);
    }
}
