using BankApi.Domain.DTOs;
using BankApi.Domain.Entities;

namespace BankApi.Domain.Interfaces
{
    public interface IClientDepositsRepository : IExcelRepository
    {
        Task<List<ClientDeposit>> GetByDateAccuralAsync(DateTime date, CancellationToken token);

        Task UpdateTotalByKeyAsync(ClientDeposit deposit, CancellationToken token);

        Task TransferMoneyOnDeposit(TransferMoneyDepositDto dto, CancellationToken token);

        Task TransferMoneyFromDeposit(TransferMoneyDepositDto dto, CancellationToken token);

        Task<List<ClientDeposit>> GetAllAsync(CancellationToken token);

        Task<ClientDeposit> GetByIdAsync(Guid clientId, Guid depositId, CancellationToken token);

        Task CreateAsync(ClientDeposit entity, CancellationToken token);

        Task UpdateAsync(ClientDeposit entity, CancellationToken token);

        Task RemoveAsync(Guid clientId, Guid depositId, CancellationToken token);
    }
}
