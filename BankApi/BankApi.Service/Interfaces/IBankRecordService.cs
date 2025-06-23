using BankApi.Domain;
using BankApi.Domain.DTOs;
using BankApi.Domain.Entities;

namespace BankApi.Service.Interfaces
{
    public interface IBankRecordService
    {
        Task CreateBankRecordAsync(BankRecordCreateDto dto, CancellationToken token);

        Task DepositMoneyOnRecord(DepositBankRecordDto dto, CancellationToken token);

        Task WithdrawalMoneyOnRecordAsync(WithdrawalBankRecordDto dto, CancellationToken token);

        Task<List<BankRecord>> GetAllAsync(CancellationToken token);
    }
}
