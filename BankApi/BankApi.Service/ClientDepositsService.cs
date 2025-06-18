using AutoMapper;
using BankApi.Domain.DTOs;
using BankApi.Domain.Entities;
using BankApi.Domain.Enums;
using BankApi.Domain.Interfaces;
using BankApi.Service.Interfaces;

namespace BankApi.Service
{
    public class ClientDepositsService(IClientDepositsRepository _clientDepositsRepository,
        IMapper _mapper) : IClientDepositsService
    {
        public async Task CreateDepositAsync(ClientDepositCreateDto dto, CancellationToken token)
        {
            var dateStart = DateTime.UtcNow;
            var datePercent = dto.Type == 0 ? dateStart.AddMinutes(1) : dateStart.AddSeconds(1);

            var deposit = _mapper.Map<ClientDeposit>(dto);

            deposit.DateStart = dateStart;
            deposit.DateAccrualPercent = datePercent;
            deposit.DateFinal = dateStart.AddMinutes(dto.Dist);

            await _clientDepositsRepository.CreateAsync(deposit, token);
        }

        public async Task<List<ClientDeposit>> GetByDateAccuralAsync(DateTime date, CancellationToken token)
        {
            var deposit = await _clientDepositsRepository.GetByDateAccuralAsync(date, token);

            return deposit;
        }

        public async Task TransferMoneyFromDepositAsync(TransferMoneyDepositDto dto, CancellationToken token)
        {
            await _clientDepositsRepository.TransferMoneyFromDeposit(dto, token);
        }

        public async Task TransferMoneyOnDepositAsync(TransferMoneyDepositDto dto, CancellationToken token)
        {
            await _clientDepositsRepository.TransferMoneyOnDeposit(dto, token);
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
