using BankApi.Domain.DTOs;

namespace BankApi.Service.Interfaces
{
    public interface IPaymentService
    {
        /// <summary>
        /// Делает запрос к repository на информацию по платежах по банковскому счету
        /// </summary>
        /// <param name="bankRecordId">ID банковского счета</param>
        /// <param name="token"></param>
        /// <returns>Список платежей</returns>
        Task<List<PaymentHistoryShowDto>> GetByBankRecordAsync(Guid bankRecordId, CancellationToken token);

    }
}
