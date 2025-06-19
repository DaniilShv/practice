using BankApi.Domain.DTOs;

namespace BankApi.Service.Interfaces
{
    public interface IBankBranchService
    {
        /// <summary>
        /// Создает экземпляр BankBranch и делает асинхронный запрос к repository
        /// </summary>
        /// <param name="dto">Информация для создания банковского отделения</param>
        /// <param name="token">Cancellation token</param>
        Task CreateBankBranchAsync(BankBranchCreateDto dto, CancellationToken token);
    }
}
