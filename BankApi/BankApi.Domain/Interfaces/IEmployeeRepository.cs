using BankApi.Domain.DTOs;
using BankApi.Domain.Entities;

namespace BankApi.Domain.Interfaces
{
    public interface IEmployeeRepository: IRepository<Employee>, IExcelRepository
    {
        Task<Employee> LoginEmployeeAsync(LoginDto dto, CancellationToken token);

        Task<Employee> GetByRefreshTokenAsync(string refreshToken, CancellationToken token);
    }
}
