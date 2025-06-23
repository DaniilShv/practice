using BankApi.Domain.DTOs;
using BankApi.Domain.Entities;

namespace BankApi.Service.Interfaces
{
    public interface IPaymentService
    {
        Task<List<PaymentHistoryShowDto>> GetByBankRecordAsync(Guid bankRecordId, CancellationToken token);

        Task<List<PaymentHistory>> GetAllAsync(CancellationToken token);

    }
}
