using AutoMapper;
using BankApi.Domain.DTOs;
using BankApi.Domain.Entities;
using BankApi.Domain.Enums;
using BankApi.Domain.Interfaces;
using BankApi.Service.Interfaces;

namespace BankApi.Service.Services
{
    public class ClientCreditService(IClientCreditRepository _clientCreditRepository,
        IMapper _mapper) : IClientCreditService
    {
        /// <summary>
        /// Создает запрос к repository о взятии кредита клиентом банка
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="token">Cancellation token</param>
        public async Task CreateCreditAsync(ClientCreditCreateDto dto, CancellationToken token)
        {
            var dtPercent = dto.Type == TypeAccrual.EveryYear ? 
                DateTime.UtcNow.AddHours(1) : DateTime.UtcNow.AddMinutes(1);

            var entity = _mapper.Map<ClientCredit>(dto);

            entity.DateStart = DateTime.UtcNow;
            entity.DateAccrualPercent = dtPercent;
            entity.DateFinal = DateTime.UtcNow.AddMinutes(dto.Dist);

            await _clientCreditRepository.CreateAsync(entity, token);
        }

        /// <summary>
        /// Получить все объекты сущности ClientCredit из базы данных
        /// </summary>
        /// <param name="token">Cancellation token</param>
        /// <returns>Список объектов ClientCredit</returns>
        public async Task<List<ClientCredit>> GetAllAsync(CancellationToken token)
        {
            return await _clientCreditRepository.GetAllAsync(token);
        }

        /// <summary>
        /// Создает запрос к repository о выплате кредита клиентом банка
        /// </summary>
        /// <param name="clientId">ID клиента</param>
        /// <param name="creditId">ID кредита</param>
        /// <param name="token">Cancellation token</param>
        public async Task RemoveCreditAsync(Guid clientId, Guid creditId, CancellationToken token)
        {

            await _clientCreditRepository.RemoveAsync(clientId, creditId, token);
        }

        /// <summary>
        /// Создает запрос к repository о пополнении кредита клиентом банка
        /// </summary>
        /// <param name="dto">Информация о кредите и банковском счете</param>
        /// <param name="token">Cancellation token</param>
        public async Task TransferMoneyOnCreditAsync(TransferMoneyCreditDto dto, CancellationToken token)
        {
            await _clientCreditRepository.TransferMoneyOnCredit(dto, token);
        }
    }
}
