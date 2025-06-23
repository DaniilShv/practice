using BankApi.Domain.DTOs;
using BankApi.Domain.Entities;

namespace BankApi.Service.Interfaces
{
    public interface IClientCreditService
    {
        Task CreateCreditAsync(ClientCreditCreateDto dto, CancellationToken token);

        Task RemoveCreditAsync(Guid clientId, Guid creditId, CancellationToken token);

        Task TransferMoneyOnCreditAsync(TransferMoneyCreditDto dto, CancellationToken token);

        Task<List<ClientCredit>> GetAllAsync(CancellationToken token);
    }
}
