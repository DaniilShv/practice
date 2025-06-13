using BankApi.Domain.DTOs;
using BankApi.Domain.Entities;
using BankApi.Domain.Interfaces;
using BankApi.Service.Interfaces;

namespace BankApi.Service
{
    public class BankRecordService(IBankRecordRepository _bankRecordRepository) : IBankRecordService
    {
        public async Task CreateBankRecordAsync(BankRecordCreateDto dto, CancellationToken token)
        {
            var record = new BankRecord
            {
                ClientId = dto.ClientId,
                BankBranchId = dto.BankBranchId,
                Total = 0
            };

            await _bankRecordRepository.CreateAsync(record, token);
        }

        public async Task DepositMoneyOnRecord(DepositBankRecordDto dto, CancellationToken token)
        {
            var record = new BankRecord
            {
                Id = dto.BankRecordId,
                Total = dto.Total
            };

            await _bankRecordRepository.DepositMoneyOnRecord(record, token);
        }

        public async Task WithdrawalMoneyOnRecordAsync(WithdrawalBankRecordDto dto, CancellationToken token)
        {
            await _bankRecordRepository.WithdrawalMoneyOnRecordAsync(dto.BankRecordId, dto.Sum, token);
        }
    }
}
