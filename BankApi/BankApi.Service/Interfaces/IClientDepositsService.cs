using BankApi.Domain;

namespace BankApi.Service.Interfaces
{
    public interface IClientDepositsService
    {
        Task CreateDepositAsync(Guid clientId, Guid depositId, decimal total,
            int dist, double percent, int type, CancellationToken token);

        Task<List<ClientDeposit>> GetByDateAccuralAsync(DateTime date, CancellationToken token);

        Task UpdateTotalByKeyAsync(Guid clientId, Guid depositId, DateTime dt, decimal total, CancellationToken token);

        Task TransferMoneyOnDepositAsync(Guid bankRecordId, Guid clientId, Guid depositId, decimal sum, CancellationToken token);

        Task TransferMoneyFromDepositAsync(Guid bankRecordId, Guid clientId, Guid depositId, decimal sum, CancellationToken token);
    }
}
