using BankApi.Domain;
using BankApi.Domain.DTOs;

namespace BankApi.Infrastructure.Interfaces
{
    public interface IBankCardRepository
    {
        Task CreateBankCardAsync(BankCard card, CancellationToken token);

        Task PayCardAsync(PayCardDto cardDto, PaymentHistory payment, CancellationToken token);
    }
}
