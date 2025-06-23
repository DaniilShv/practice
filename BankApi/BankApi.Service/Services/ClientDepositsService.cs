using AutoMapper;
using BankApi.Domain.DTOs;
using BankApi.Domain.Entities;
using BankApi.Domain.Enums;
using BankApi.Domain.Interfaces;
using BankApi.Service.Interfaces;

namespace BankApi.Service.Services
{
    public class ClientDepositsService(IClientDepositsRepository _clientDepositsRepository,
        IMapper _mapper) : IClientDepositsService
    {
        /// <summary>
        /// Создает запрос к repository об открытии вклада клиентом банка
        /// </summary>
        /// <param name="dto">Информация о клиенте и вкладе</param>
        /// <param name="token">Cancellation token</param>
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

        /// <summary>
        /// Получить все объекты сущности ClientDeposit из базы данных
        /// </summary>
        /// <param name="token">Cancellation token</param>
        /// <returns>Список объектов ClientDeposit</returns>
        public async Task<List<ClientDeposit>> GetAllAsync(CancellationToken token)
        {
            return await _clientDepositsRepository.GetAllAsync(token);
        }

        /// <summary>
        /// Информация о вкладах по дате начисления процентов
        /// </summary>
        /// <param name="date">Начисление процентов</param>
        /// <param name="token">Cancellation token</param>
        /// <returns>Список вкладов</returns>
        public async Task<List<ClientDeposit>> GetByDateAccuralAsync(DateTime date, CancellationToken token)
        {
            var deposit = await _clientDepositsRepository.GetByDateAccuralAsync(date, token);

            return deposit;
        }

        /// <summary>
        /// Создает зпрос к repository о пополнении банковского счета со вклада
        /// </summary>
        /// <param name="dto">Информация о вкладе и банковском счете</param>
        /// <param name="token">Cancellation token</param>
        public async Task TransferMoneyFromDepositAsync(TransferMoneyDepositDto dto, CancellationToken token)
        {
            await _clientDepositsRepository.TransferMoneyFromDeposit(dto, token);
        }

        /// <summary>
        /// Создает запрос к repository о пополнении вклада клиентом банка
        /// </summary>
        /// <param name="dto">Информация о вкладе и банковском счете</param>
        /// <param name="token">Cancellation token</param>
        public async Task TransferMoneyOnDepositAsync(TransferMoneyDepositDto dto, CancellationToken token)
        {
            await _clientDepositsRepository.TransferMoneyOnDeposit(dto, token);
        }

        /// <summary>
        /// Обновление информации о сумме вклада
        /// </summary>
        /// <param name="clientId">ID клиента</param>
        /// <param name="depositId">ID вклада</param>
        /// <param name="dt">Начисление процентов</param>
        /// <param name="total">Сумма</param>
        /// <param name="token">Cancellation token</param>
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
