using BankApi.Domain.DTOs;

namespace BankApi.Service.Interfaces
{
    public interface IEmployeeService
    {
        Task CreateEmployeeAsync(CreateEmployeeDto employee, CancellationToken token);

        Task<EmployeeShowDto> LoginClientAsync(LoginDto dto, CancellationToken token);
    }
}
