using BankApi.Domain;
using BankApi.Domain.DTOs;

namespace BankApi.Infrastructure.Interfaces
{
    public interface IClientDepositsRepository
    {
        Task CreateDepositAsync(ClientDeposit deposit, CancellationToken token);

        Task<List<ClientDeposit>> GetByDateAccuralAsync(DateTime date, CancellationToken token);

        Task UpdateTotalByKeyAsync(ClientDeposit deposit, CancellationToken token);

        Task TransferMoneyOnDeposit(TransferMoneyDepositDto dto, CancellationToken token);

        Task TransferMoneyFromDeposit(TransferMoneyDepositDto dto, CancellationToken token);
    }
}
