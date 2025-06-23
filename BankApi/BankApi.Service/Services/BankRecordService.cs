using AutoMapper;
using BankApi.Domain.DTOs;
using BankApi.Domain.Entities;
using BankApi.Domain.Interfaces;
using BankApi.Service.Interfaces;

namespace BankApi.Service.Services
{
    public class BankRecordService(IBankRecordRepository _bankRecordRepository,
        IMapper _mapper) : IBankRecordService
    {
        /// <summary>
        /// Делает запрос к repository о создании банковского счета
        /// </summary>
        /// <param name="dto">Информация для создания банковского счета</param>
        /// <param name="token">Cancellation token</param>
        public async Task CreateBankRecordAsync(BankRecordCreateDto dto, CancellationToken token)
        {
            var record = _mapper.Map<BankRecord>(dto);

            record.Total = 0;

            await _bankRecordRepository.CreateAsync(record, token);
        }

        /// <summary>
        /// Делает запрос к repository о пополнении банковского счета
        /// </summary>
        /// <param name="dto">Информация о финансовой операции</param>
        /// <param name="token">Cancellation token</param>
        public async Task DepositMoneyOnRecord(DepositBankRecordDto dto, CancellationToken token)
        {
            var record = new BankRecord
            {
                Id = dto.BankRecordId,
                Total = dto.Total
            };

            await _bankRecordRepository.DepositMoneyOnRecord(record, token);
        }

        /// <summary>
        /// Получить все объекты сущности BankRecord из базы данных
        /// </summary>
        /// <param name="token">Cancellation token</param>
        /// <returns>Список объектов BankRecord</returns>
        public async Task<List<BankRecord>> GetAllAsync(CancellationToken token)
        {
            return await _bankRecordRepository.GetAllAsync(token);
        }

        /// <summary>
        /// Делает запрос к repository о снятии денег из банковского счета
        /// </summary>
        /// <param name="dto">Информация о финансовой операции</param>
        /// <param name="token">Cancellation token</param>
        public async Task WithdrawalMoneyOnRecordAsync(WithdrawalBankRecordDto dto, CancellationToken token)
        {
            await _bankRecordRepository.WithdrawalMoneyOnRecordAsync(dto.BankRecordId, dto.Sum, token);
        }
    }
}
