namespace BankApi.Service.Interfaces
{
    public interface IClientDepositsService
    {
        Task CreateDepositAsync(Guid clientId, Guid depositId, decimal total,
            int dist, double percent, int type, CancellationToken token);
    }
}
