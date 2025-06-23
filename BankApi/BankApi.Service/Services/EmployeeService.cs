using AutoMapper;
using BankApi.Domain.DTOs;
using BankApi.Domain.Entities;
using BankApi.Domain.Interfaces;
using BankApi.Service.Interfaces;
using Identity.PasswordHasher;
using System.Data;
using System.Security.Claims;

namespace BankApi.Service.Services
{
    public class EmployeeService(IEmployeeRepository _employeeRepository,
        IMapper _mapper) : IEmployeeService
    {
        /// <summary>
        /// Делает запрос к repository на создание сотрудника в БД
        /// </summary>
        /// <param name="employee">Информация о сотруднике</param>
        public async Task CreateEmployeeAsync(CreateEmployeeDto employee, CancellationToken token)
        {
            var hasher = new PasswordHasher();

            var employeeItem = _mapper.Map<Employee>(employee);

            employeeItem.PasswordHash = hasher.HashPassword(employee.Password);

            await _employeeRepository.CreateAsync(employeeItem, token);
        }

        /// <summary>
        /// Получить все объекты сущности Employee из базы данных
        /// </summary>
        /// <param name="token">Cancellation token</param>
        /// <returns>Список объектов Employee</returns>
        public async Task<List<Employee>> GetAllAsync(CancellationToken token)
        {
            return await _employeeRepository.GetAllAsync(token);
        }

        /// <summary>
        /// Делает запрос к repository о сотруднике банка по refresh token
        /// </summary>
        /// <returns>Сотрудник банка</returns>
        public async Task<Employee> GetByRefreshTokenAsync(string refreshToken, CancellationToken token)
        {
            var client = await _employeeRepository.GetByRefreshTokenAsync(refreshToken, token);

            if (client == null)
                throw new DataException("Пользователь с этим refresh Token не найден в базе данных");

            return client;
        }

        /// <summary>
        /// Получить сведения о сотруднике банка
        /// </summary>
        /// <param name="employee">Информация о сотруднике банка</param>
        /// <returns>Сведения о клиенте банка</returns>
        public List<Claim> GetClaimEmployee(EmployeeShowDto employee)
        {
            var claims = new List<Claim>();

            switch (employee.Position)
            {
                case "Employee":
                    claims.Add(new Claim("EmployeeStatus", "Employee"));
                    break;
                case "Manager":
                    claims.Add(new Claim("EmployeeStatus", "Manager"));
                    break;
                case "Director":
                    claims.Add(new Claim("EmployeeStatus", "Director"));
                    break;
            }

            return claims;
        }

        /// <summary>
        /// Проверка сотрудника в базе данных по логину и паролю
        /// </summary>
        /// <param name="dto">Логин и пароль</param>
        /// <returns>Сотрудник банка</returns>
        public async Task<EmployeeShowDto> LoginEmployeeAsync(LoginDto dto, string refreshToken,
            CancellationToken token)
        {
            var hasher = new PasswordHasher();

            var employee = await _employeeRepository.LoginEmployeeAsync(dto, token);

            employee.RefreshToken = refreshToken;
            employee.RefreshTokenExpiryTime = DateTime.UtcNow.AddYears(100);

            if (employee != null)
            {
                if (hasher.VerifyHashedPassword(employee.PasswordHash, dto.Password))
                {
                    await _employeeRepository.UpdateAsync(employee, token);

                    var employeeShowDto = _mapper.Map<EmployeeShowDto>(employee);

                    return employeeShowDto;
                }
                else
                    throw new Exception("Введите верный пароль");
            }
            else
                throw new Exception("Пользователь с этим логином не найден в базе данных");
        }

        /// <summary>
        /// Запрос к repository на удаление сотрудника банка по ID
        /// </summary>
        /// <param name="id">ID сотрудника</param>
        public async Task RemoveEmployeeAsync(Guid id, CancellationToken token)
        {
            await _employeeRepository.RemoveAsync(id, token);
        }

        /// <summary>
        /// Обновить информацию о должности сотрудника
        /// </summary>
        /// <param name="id">ID сотрудника</param>
        /// <param name="position">Должность сотрудника</param>
        public async Task UpdatePositionEmployeeAsync(Guid id, string position, CancellationToken token)
        {
            var item = new Employee { Id = id, Position = position };

            await _employeeRepository.UpdateAsync(item, token);
        }
    }
}
