using BankApi.Domain.DTOs;
using BankApi.Domain.Entities;

namespace BankApi.Domain.Interfaces
{
    public interface IEmployeeRepository: IRepository<Employee>
    {
        /// <summary>
        /// Информация о сотруднике по логину
        /// </summary>
        /// <param name="dto">Экземпляр LoginDto</param>
        /// <param name="token">Cancellation token</param>
        /// <returns>Экземпляр Employee</returns>
        Task<Employee> LoginEmployeeAsync(LoginDto dto, CancellationToken token);

        /// <summary>
        /// Информация о клиенте по refresh token
        /// </summary>
        /// <param name="refreshToken">refresh token</param>
        /// <param name="token">Cancellation token</param>
        /// <returns>Экземпляр CLient</returns>
        Task<Employee> GetByRefreshTokenAsync(string refreshToken, CancellationToken token);
    }
}
