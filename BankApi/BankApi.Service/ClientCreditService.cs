using BankApi.Domain.DTOs;
using BankApi.Domain.Entities;
using BankApi.Domain.Enums;
using BankApi.Domain.Interfaces;
using BankApi.Service.Interfaces;

namespace BankApi.Service
{
    public class ClientCreditService(IClientCreditRepository _clientCreditRepository) : IClientCreditService
    {
        public async Task CreateCreditAsync(ClientCreditCreateDto dto, CancellationToken token)
        {
            var dtPercent = dto.Type == TypeAccrual.EveryYear ? 
                DateTime.UtcNow.AddHours(1) : DateTime.UtcNow.AddMinutes(1);

            var entity = new ClientCredit
            {
                ClientId = dto.ClientId,
                CreditId = dto.CreditId,
                DateStart = DateTime.UtcNow,
                DateAccrualPercent = dtPercent,
                DateFinal = DateTime.UtcNow.AddMinutes(dto.Dist),
                Percent = dto.Percent,
                Total = dto.Total,
                Type = dto.Type,
            };

            await _clientCreditRepository.CreateAsync(entity, token);
        }

        public async Task RemoveCreditAsync(Guid clientId, Guid creditId, CancellationToken token)
        {

            await _clientCreditRepository.RemoveAsync(clientId, creditId, token);
        }
    }
}
