using AutoMapper;
using BankApi.Domain.DTOs;
using BankApi.Domain.Entities;
using BankApi.Domain.Interfaces;
using BankApi.Service.Interfaces;
using Identity.PasswordHasher;
using System.Data;
using System.Security.Claims;

namespace BankApi.Service
{
    public class EmployeeService(IEmployeeRepository _employeeRepository,
        IMapper _mapper) : IEmployeeService
    {
        public async Task CreateEmployeeAsync(CreateEmployeeDto employee, CancellationToken token)
        {
            var hasher = new PasswordHasher();

            var employeeItem = _mapper.Map<Employee>(employee);

            employeeItem.PasswordHash = hasher.HashPassword(employee.Password);

            await _employeeRepository.CreateAsync(employeeItem, token);
        }

        public async Task<Employee> GetByRefreshTokenAsync(string refreshToken, CancellationToken token)
        {
            var client = await _employeeRepository.GetByRefreshTokenAsync(refreshToken, token);

            if (client == null)
                throw new DataException("Укажите верный refresh Token");

            return client;
        }

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
                throw new Exception("Введите верный логин");
        }

        public async Task RemoveEmployeeAsync(Guid id, CancellationToken token)
        {
            await _employeeRepository.RemoveAsync(id, token);
        }

        public async Task UpdatePositionEmployeeAsync(Guid id, string position, CancellationToken token)
        {
            var item = new Employee { Id = id, Position = position };

            await _employeeRepository.UpdateAsync(item, token);
        }
    }
}
