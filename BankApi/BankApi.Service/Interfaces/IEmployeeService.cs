using BankApi.Domain.DTOs;
using BankApi.Domain.Entities;
using System.Security.Claims;

namespace BankApi.Service.Interfaces
{
    public interface IEmployeeService
    {
        Task CreateEmployeeAsync(CreateEmployeeDto employee, CancellationToken token);

        Task<EmployeeShowDto> LoginEmployeeAsync(LoginDto dto, string refreshToken, CancellationToken token);

        List<Claim> GetClaimEmployee(EmployeeShowDto employee);

        Task<Employee> GetByRefreshTokenAsync(string refreshToken, CancellationToken token);

        Task UpdatePositionEmployeeAsync(Guid id, string position, CancellationToken token);

        Task RemoveEmployeeAsync(Guid id, CancellationToken token);
    }
}
