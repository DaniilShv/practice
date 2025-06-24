using AutoMapper;
using BankApi.Domain.DTOs;
using BankApi.Domain.Entities;
using BankApi.Domain.Interfaces;
using BankApi.Service.Interfaces;
using System.Collections;

namespace BankApi.Service.Services
{
    public class BankBranchService(IBankBranchRepository _bankBranchRepository,
        IMapper _mapper) : IBankBranchService
    {
        /// <summary>
        /// Создает экземпляр BankBranch и делает асинхронный запрос к repository
        /// </summary>
        /// <param name="dto">Информация для создания банковского отделения</param>
        /// <param name="token">Cancellation token</param>
        public async Task CreateBankBranchAsync(BankBranchCreateDto dto, CancellationToken token)
        {
            var bank = _mapper.Map<BankBranch>(dto);

            await _bankBranchRepository.CreateAsync(bank, token);
        }

        /// <summary>
        /// Получить все объекты сущности BankBranch из базы данных
        /// </summary>
        /// <param name="token">Cancellation token</param>
        /// <returns>Список объектов BankBranch</returns>
        public async Task<List<BankBranch>> GetAllAsync(CancellationToken token)
        {
            return await _bankBranchRepository.GetAllAsync(token);
        }
    }
}
