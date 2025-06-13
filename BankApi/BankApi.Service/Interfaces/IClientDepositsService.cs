using BankApi.Domain.DTOs;
using BankApi.Domain.Entities;

namespace BankApi.Service.Interfaces
{
    public interface IClientDepositsService
    {
        Task CreateDepositAsync(ClientDepositCreateDto dto, CancellationToken token);

        Task<List<ClientDeposit>> GetByDateAccuralAsync(DateTime date, CancellationToken token);

        Task UpdateTotalByKeyAsync(Guid clientId, Guid depositId, DateTime dt, decimal total, CancellationToken token);

        Task TransferMoneyOnDepositAsync(TransferMoneyDepositDto dto, CancellationToken token);

        Task TransferMoneyFromDepositAsync(TransferMoneyDepositDto dto, CancellationToken token);
    }
}
