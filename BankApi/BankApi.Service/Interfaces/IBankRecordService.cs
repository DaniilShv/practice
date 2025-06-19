using BankApi.Domain;
using BankApi.Domain.DTOs;

namespace BankApi.Service.Interfaces
{
    public interface IBankRecordService
    {
        /// <summary>
        /// Делает запрос к repository о создании банковского счета
        /// </summary>
        /// <param name="dto">Информация для создания банковского счета</param>
        /// <param name="token">Cancellation token</param>
        Task CreateBankRecordAsync(BankRecordCreateDto dto, CancellationToken token);

        /// <summary>
        /// Делает запрос к repository о пополнении банковского счета
        /// </summary>
        /// <param name="dto">Информация о финансовой операции</param>
        /// <param name="token">Cancellation token</param>
        Task DepositMoneyOnRecord(DepositBankRecordDto dto, CancellationToken token);

        /// <summary>
        /// Делает запрос к repository о снятии денег из банковского счета
        /// </summary>
        /// <param name="dto">Информация о финансовой операции</param>
        /// <param name="token">Cancellation token</param>
        Task WithdrawalMoneyOnRecordAsync(WithdrawalBankRecordDto dto, CancellationToken token);
    }
}
