using BankApi.Domain.DTOs;
using BankApi.Domain.Entities;
using BankApi.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BankApi.Infrastructure.Repository
{
    public class EmployeeRepository(BankDbContext _context) : IEmployeeRepository
    {
        public async Task CreateAsync(Employee employee, CancellationToken token)
        {
            await _context.Employees.AddAsync(employee, token);
            
            await _context.SaveChangesAsync(token);
        }

        public async Task<List<Employee>> GetAllAsync(CancellationToken token)
        {
            return await _context.Employees.ToListAsync(token);
        }

        public async Task<Employee> GetByIdAsync(Guid id, CancellationToken token)
        {
            var item = await _context.Employees.FirstOrDefaultAsync(x => x.Id == id, token);

            if (item == null)
                throw new ArgumentNullException("Укажите корректно идентификатор");

            return item;
        }

        public async Task<Employee> GetByRefreshTokenAsync(string refreshToken, CancellationToken token)
        {
            var item = await _context.Employees.FirstOrDefaultAsync(x => x.RefreshToken == refreshToken);

            return item;
        }

        public async Task<Employee> LoginEmployeeAsync(LoginDto dto, CancellationToken token)
        {
            return await _context.Employees.FirstOrDefaultAsync(x => x.Login == dto.Login);
        }

        public async Task RemoveAsync(Guid id, CancellationToken token)
        {
            await _context.Employees
                .Where(x => x.Id == id)
                .ExecuteDeleteAsync(token);

            await _context.SaveChangesAsync(token);
        }

        public async Task UpdateAsync(Employee entity, CancellationToken token)
        {
            var item = await _context.Employees.FirstOrDefaultAsync(x => x.Id == entity.Id);

            item.Position = entity.Position;

            _context.Employees.Update(item);

            await _context.SaveChangesAsync(token);
        }
    }
}
