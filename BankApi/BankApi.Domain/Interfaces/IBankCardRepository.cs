using BankApi.Domain.DTOs;
using BankApi.Domain.Entities;

namespace BankApi.Domain.Interfaces
{
    public interface IBankCardRepository : IRepository<BankCard>, IExcelRepository
    {
        Task PayCardAsync(BankCardPayDto cardDto, PaymentHistory payment, CancellationToken token);
    }
}
