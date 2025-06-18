using BankApi.Domain.DTOs;
using BankApi.Domain.Entities;

namespace BankApi.Domain.Interfaces
{
    public interface IPaymentRepository : IRepository<PaymentHistory>
    {
        Task<List<PaymentHistoryShowDto>> GetByBankRecordAsync(Guid id, CancellationToken token);
    }
}
