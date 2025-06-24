using BankApi.Domain.DTOs;
using BankApi.Domain.Entities;
using BankApi.Domain.Interfaces;
using BankApi.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace BankApi.Infrastructure.Repository
{
    public class EmployeeRepository(BankDbContext _context) : IEmployeeRepository
    {
        /// <summary>
        /// Создать объект сотрудника в БД
        /// </summary>
        /// <param name="entity">Экземпляр объекта</param>
        /// <param name="token">Cancellation token</param>
        public async Task CreateAsync(Employee employee, CancellationToken token)
        {
            await _context.Employees.AddAsync(employee, token);
            
            await _context.SaveChangesAsync(token);
        }

        /// <summary>
        /// Получить информацию о всех сотрудниках из БД
        /// </summary>
        /// <param name="token">Cancellation token</param>
        /// <returns>Список объектов</returns>
        public async Task<List<Employee>> GetAllAsync(CancellationToken token)
        {
            return await _context.Employees.ToListAsync(token);
        }

        public async Task<Employee> GetByIdAsync(Guid id, CancellationToken token)
        {
            var item = await _context.Employees.FirstOrDefaultAsync(x => x.Id == id, token);

            if (item == null)
                throw new ArgumentNullException("Сотрудник с таким ID не найден в базе данных банка");

            return item;
        }

        /// <summary>
        /// Информация о клиенте по refresh token
        /// </summary>
        /// <param name="refreshToken">refresh token</param>
        /// <param name="token">Cancellation token</param>
        /// <returns>Экземпляр CLient</returns>
        public async Task<Employee> GetByRefreshTokenAsync(string refreshToken, CancellationToken token)
        {
            var item = await _context.Employees.FirstOrDefaultAsync(x => x.RefreshToken == refreshToken);

            return item;
        }

        public DataTable GetDataTable()
        {
            return _context.Employees
                .Select(x => new
                {
                    Id = x.Id,
                    Surname = x.Surname,
                    Name = x.Name,
                    Patronymic = x.Patronymic,
                    DateBirth = x.DateBirth,
                    BankBranchId = x.BankBranchId,
                    Education = x.Education,
                    Gender = x.Gender,
                    Position = x.Position,
                    Salary = x.Salary,
                    Login = x.Login,
                    PasswordHash = x.PasswordHash
                })
                .ToDataTable();
        }

        public string GetTableName()
        {
            return "Employees";
        }

        /// <summary>
        /// Информация о сотруднике по логину
        /// </summary>
        /// <param name="dto">Экземпляр LoginDto</param>
        /// <param name="token">Cancellation token</param>
        /// <returns>Экземпляр Employee</returns>
        public async Task<Employee> LoginEmployeeAsync(LoginDto dto, CancellationToken token)
        {
            return await _context.Employees.FirstOrDefaultAsync(x => x.Login == dto.Login);
        }

        /// <summary>
        /// Метод для удаления данных о сотруднике по ID
        /// </summary>
        /// <param name="id">Идентификатор объекта</param>
        /// <param name="token">Cancellation token</param>
        public async Task RemoveAsync(Guid id, CancellationToken token)
        {
            await _context.Employees
                .Where(x => x.Id == id)
                .ExecuteDeleteAsync(token);

            await _context.SaveChangesAsync(token);
        }

        /// <summary>
        /// Метод для обновления данных сотрудника в БД
        /// </summary>
        /// <param name="entity">Экземпляр объекта</param>
        /// <param name="token">Cancellation token</param>
        public async Task UpdateAsync(Employee entity, CancellationToken token)
        {
            var item = await _context.Employees.FirstOrDefaultAsync(x => x.Id == entity.Id);

            item.Position = entity.Position;

            _context.Employees.Update(item);

            await _context.SaveChangesAsync(token);
        }
    }
}
