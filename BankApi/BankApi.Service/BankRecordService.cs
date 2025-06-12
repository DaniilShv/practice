using BankApi.Domain;
using BankApi.Infrastructure.Interfaces;
using BankApi.Service.Interfaces;

namespace BankApi.Service
{
    public class BankRecordService(IBankRecordRepository _bankRecordRepository) : IBankRecordService
    {
        public async Task CreateBankRecordAsync(Guid clientId, Guid bankBranchId, CancellationToken token)
        {
            var record = new BankRecord
            {
                ClientId = clientId,
                BankBranchId = bankBranchId,
                Total = 0
            };

            await _bankRecordRepository.CreateBankRecordAsync(record, token);
        }

        public async Task DepositMoneyOnRecord(Guid bankRecordId, decimal total, CancellationToken token)
        {
            var record = new BankRecord
            {
                Id = bankRecordId,
                Total = total
            };

            await _bankRecordRepository.DepositMoneyOnRecord(record, token);
        }

        public async Task WithdrawalMoneyOnRecordAsync(Guid bankRecordId, decimal sum, CancellationToken token)
        {
            await _bankRecordRepository.WithdrawalMoneyOnRecordAsync(bankRecordId, sum, token);
        }
    }
}
