using BankApi.Domain.DTOs;
using BankApi.Domain.Entities;

namespace BankApi.Domain.Interfaces
{
    public interface IEmployeeRepository: IRepository<Employee>
    {
        Task<Employee> LoginEmployeeAsync(LoginDto dto, CancellationToken token);
    }
}
