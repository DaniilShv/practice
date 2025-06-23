using BankApi.Domain.DTOs;

namespace BankApi.Service.Interfaces
{
    public interface IPaymentService
    {
        Task<List<PaymentHistoryShowDto>> GetByBankRecordAsync(Guid bankRecordId, CancellationToken token);

    }
}
