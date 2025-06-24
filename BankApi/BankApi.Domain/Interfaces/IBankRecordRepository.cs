using BankApi.Domain.Entities;

namespace BankApi.Domain.Interfaces
{
    public interface IBankRecordRepository : IRepository<BankRecord>, IExcelRepository
    {
        Task DepositMoneyOnRecord(BankRecord record, CancellationToken token);

        Task WithdrawalMoneyOnRecordAsync(Guid bankRecordId, decimal sum, CancellationToken token);
    }
}
