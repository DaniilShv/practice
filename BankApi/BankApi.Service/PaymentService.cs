using BankApi.Domain.DTOs;
using BankApi.Domain.Interfaces;
using BankApi.Service.Interfaces;

namespace BankApi.Service
{
    public class PaymentService(IPaymentRepository _paymentRepository) : IPaymentService
    {
        public async Task<List<PaymentHistoryShowDto>> GetByBankRecordAsync(Guid bankRecordId, CancellationToken token)
        {
            return await _paymentRepository.GetByBankRecordAsync(bankRecordId, token);
        }
    }
}
