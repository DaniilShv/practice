using BankApi.Domain.DTOs;

namespace BankApi.Service.Interfaces
{
    public interface IClientCreditService
    {
        Task CreateCreditAsync(ClientCreditCreateDto dto, CancellationToken token);

        Task RemoveCreditAsync(Guid clientId, Guid creditId, CancellationToken token);

        Task TransferMoneyOnCreditAsync(TransferMoneyCreditDto dto, CancellationToken token);
    }
}
