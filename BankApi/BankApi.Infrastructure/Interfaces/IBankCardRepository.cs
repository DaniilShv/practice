using BankApi.Domain;

namespace BankApi.Infrastructure.Interfaces
{
    public interface IBankCardRepository
    {
        Task CreateBankCardAsync(BankCard card, CancellationToken token);
    }
}
