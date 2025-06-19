using BankApi.Domain.Entities;

namespace BankApi.Domain.Interfaces
{
    public interface IBankRecordRepository : IRepository<BankRecord>
    {
        /// <summary>
        /// Метод реализующий функцию пополнения банковского счета
        /// </summary>
        /// <param name="record">экземпляр BankRecord</param>
        /// <param name="token">Cancellation Token</param>
        Task DepositMoneyOnRecord(BankRecord record, CancellationToken token);

        /// <summary>
        /// Метод реализующий функцию снятия денег из банковского счета
        /// </summary>
        /// <param name="bankRecordId">Идентификатор банковского счета</param>
        /// <param name="sum">Сумма</param>
        /// <param name="token">Cancellation Token</param>
        Task WithdrawalMoneyOnRecordAsync(Guid bankRecordId, decimal sum, CancellationToken token);
    }
}
