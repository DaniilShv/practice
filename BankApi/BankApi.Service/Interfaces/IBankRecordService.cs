using BankApi.Domain;

namespace BankApi.Service.Interfaces
{
    public interface IBankRecordService
    {
        Task CreateBankRecordAsync(Guid clientId, Guid bankBranchId, CancellationToken token);

        Task DepositMoneyOnRecord(Guid bankRecordId, decimal total, CancellationToken token);

        Task WithdrawalMoneyOnRecordAsync(Guid bankRecordId, decimal sum, CancellationToken token);
    }
}
