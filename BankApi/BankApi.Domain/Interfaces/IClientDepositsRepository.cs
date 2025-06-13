using BankApi.Domain.DTOs;
using BankApi.Domain.Entities;

namespace BankApi.Domain.Interfaces
{
    public interface IClientDepositsRepository : IRepository<ClientDeposit>
    {
        Task<List<ClientDeposit>> GetByDateAccuralAsync(DateTime date, CancellationToken token);

        Task UpdateTotalByKeyAsync(ClientDeposit deposit, CancellationToken token);

        Task TransferMoneyOnDeposit(TransferMoneyDepositDto dto, CancellationToken token);

        Task TransferMoneyFromDeposit(TransferMoneyDepositDto dto, CancellationToken token);
    }
}
