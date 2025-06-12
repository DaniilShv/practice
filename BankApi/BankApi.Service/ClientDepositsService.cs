using BankApi.Domain;
using BankApi.Domain.DTOs;
using BankApi.Domain.Enums;
using BankApi.Infrastructure.Interfaces;
using BankApi.Service.Interfaces;

namespace BankApi.Service
{
    public class ClientDepositsService(IClientDepositsRepository _clientDepositsRepository) : IClientDepositsService
    {
        public async Task CreateDepositAsync(Guid clientId, Guid depositId, decimal total, 
            int dist, double percent, int type, CancellationToken token)
        {
            var dateStart = DateTime.UtcNow;
            var datePercent = type == 0 ? dateStart.AddMinutes(1) : dateStart.AddSeconds(1);

            var deposit = new ClientDeposit
            {
                ClientId = clientId,
                DepositId = depositId,
                Total = total,
                Percent = percent,
                Type = (TypeAccrual)type,
                DateStart = dateStart,
                DateAccrualPercent = datePercent,
                DateFinal = dateStart.AddMinutes(dist)
            };

            await _clientDepositsRepository.CreateDepositAsync(deposit, token);
        }

        public async Task<List<ClientDeposit>> GetByDateAccuralAsync(DateTime date, CancellationToken token)
        {
            return await _clientDepositsRepository.GetByDateAccuralAsync(date, token);
        }

        public async Task TransferMoneyFromDepositAsync(Guid bankRecordId, Guid clientId, Guid depositId, decimal sum, CancellationToken token)
        {
            var transferMoneyDto = new TransferMoneyDepositDto
            {
                BankRecordId = bankRecordId,
                ClientId = clientId,
                DepositId = depositId,
                Sum = sum
            };

            await _clientDepositsRepository.TransferMoneyFromDeposit(transferMoneyDto, token);
        }

        public async Task TransferMoneyOnDepositAsync(Guid bankRecordId, Guid clientId, Guid depositId, 
            decimal sum, CancellationToken token)
        {
            var transferMoneyDto = new TransferMoneyDepositDto
            {
                BankRecordId = bankRecordId,
                ClientId = clientId,
                DepositId = depositId,
                Sum = sum
            };

            await _clientDepositsRepository.TransferMoneyOnDeposit(transferMoneyDto, token);
        }

        public async Task UpdateTotalByKeyAsync(Guid clientId, Guid depositId, DateTime dt, decimal total, 
            CancellationToken token)
        {
            var deposit = new ClientDeposit
            {
                ClientId = clientId,
                DepositId = depositId,
                Total = total,
                DateAccrualPercent = dt
            };

            await _clientDepositsRepository.UpdateTotalByKeyAsync(deposit, token);
        }
    }
}
