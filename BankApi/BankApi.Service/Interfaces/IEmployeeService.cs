using BankApi.Domain.DTOs;
using BankApi.Domain.Entities;
using System.Security.Claims;

namespace BankApi.Service.Interfaces
{
    public interface IEmployeeService
    {
        /// <summary>
        /// Делает запрос к repository на создание сотрудника в БД
        /// </summary>
        /// <param name="employee">Информация о сотруднике</param>
        Task CreateEmployeeAsync(CreateEmployeeDto employee, CancellationToken token);

        /// <summary>
        /// Проверка сотрудника в базе данных по логину и паролю
        /// </summary>
        /// <param name="dto">Логин и пароль</param>
        /// <returns>Сотрудник банка</returns>
        Task<EmployeeShowDto> LoginEmployeeAsync(LoginDto dto, string refreshToken, CancellationToken token);

        /// <summary>
        /// Получить сведения о сотруднике банка
        /// </summary>
        /// <param name="employee">Информация о сотруднике банка</param>
        /// <returns>Сведения о клиенте банка</returns>
        List<Claim> GetClaimEmployee(EmployeeShowDto employee);

        /// <summary>
        /// Делает запрос к repository о сотруднике банка по refresh token
        /// </summary>
        /// <returns>Сотрудник банка</returns>
        Task<Employee> GetByRefreshTokenAsync(string refreshToken, CancellationToken token);

        /// <summary>
        /// Обновить информацию о должности сотрудника
        /// </summary>
        /// <param name="id">ID сотрудника</param>
        /// <param name="position">Должность сотрудника</param>
        Task UpdatePositionEmployeeAsync(Guid id, string position, CancellationToken token);

        /// <summary>
        /// Запрос к repository на удаление сотрудника банка по ID
        /// </summary>
        /// <param name="id">ID сотрудника</param>
        Task RemoveEmployeeAsync(Guid id, CancellationToken token);
    }
}
