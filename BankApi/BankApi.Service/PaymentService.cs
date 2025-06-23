using BankApi.Domain.DTOs;
using BankApi.Domain.Interfaces;
using BankApi.Service.Interfaces;

namespace BankApi.Service
{
    public class PaymentService(IPaymentRepository _paymentRepository) : IPaymentService
    {
        /// <summary>
        /// Делает запрос к repository на информацию по платежах по банковскому счету
        /// </summary>
        /// <param name="bankRecordId">ID банковского счета</param>
        /// <param name="token"></param>
        /// <returns>Список платежей</returns>
        public async Task<List<PaymentHistoryShowDto>> GetByBankRecordAsync(Guid bankRecordId, CancellationToken token)
        {
            return await _paymentRepository.GetByBankRecordAsync(bankRecordId, token);
        }
    }
}
