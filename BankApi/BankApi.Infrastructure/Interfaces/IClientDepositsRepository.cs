using BankApi.Domain;

namespace BankApi.Infrastructure.Interfaces
{
    public interface IClientDepositsRepository
    {
        Task CreateDepositAsync(ClientDeposit deposit, CancellationToken token);
    }
}
