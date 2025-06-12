using BankApi.Domain;

namespace BankApi.Infrastructure.Interfaces
{
    public interface IBankRecordRepository
    {
        Task CreateBankRecordAsync(BankRecord record, CancellationToken token);

        Task DepositMoneyOnRecord(BankRecord record, CancellationToken token);

        Task WithdrawalMoneyOnRecordAsync(Guid bankRecordId, decimal sum, CancellationToken token);
    }
}
