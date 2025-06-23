using BankApi.Domain;
using BankApi.Domain.DTOs;

namespace BankApi.Service.Interfaces
{
    public interface IBankRecordService
    {
        Task CreateBankRecordAsync(BankRecordCreateDto dto, CancellationToken token);

        Task DepositMoneyOnRecord(DepositBankRecordDto dto, CancellationToken token);

        Task WithdrawalMoneyOnRecordAsync(WithdrawalBankRecordDto dto, CancellationToken token);
    }
}
