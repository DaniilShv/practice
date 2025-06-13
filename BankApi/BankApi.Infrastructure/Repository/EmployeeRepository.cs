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

        public Task<Employee> GetById(Employee entity, CancellationToken token)
        {
            return _context.Employees.FirstOrDefaultAsync(x => x.Id == entity.Id, token);
        }

        public async Task<Employee> LoginEmployeeAsync(LoginDto dto, CancellationToken token)
        {
            return await _context.Employees.FirstOrDefaultAsync(x => x.Login == dto.Login);
        }

        public async Task RemoveAsync(Employee entity, CancellationToken token)
        {
            _context.Employees.Remove(entity);

            await _context.SaveChangesAsync(token);
        }

        public async Task UpdateAsync(Employee entity, CancellationToken token)
        {
            _context.Employees.Update(entity);

            await _context.SaveChangesAsync(token);
        }
    }
}
