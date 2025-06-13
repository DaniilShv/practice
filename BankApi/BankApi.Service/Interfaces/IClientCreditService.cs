using BankApi.Domain.DTOs;

namespace BankApi.Service.Interfaces
{
    public interface IClientCreditService
    {
        Task CreateCreditAsync(ClientCreditCreateDto dto, CancellationToken token);

        Task RemoveCreditAsync(ClientCreditRemoveDto dto, CancellationToken token);
    }
}
