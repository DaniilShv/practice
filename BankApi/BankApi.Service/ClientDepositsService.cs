using BankApi.Domain;
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
    }
}
