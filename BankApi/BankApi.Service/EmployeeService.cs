using AutoMapper;
using BankApi.Domain.DTOs;
using BankApi.Domain.Entities;
using BankApi.Domain.Interfaces;
using BankApi.Service.Interfaces;
using Identity.PasswordHasher;

namespace BankApi.Service
{
    public class EmployeeService(IEmployeeRepository _employeeRepository,
        IMapper _mapper) : IEmployeeService
    {
        public async Task CreateEmployeeAsync(CreateEmployeeDto employee, CancellationToken token)
        {
            var hasher = new PasswordHasher();

            var employeeItem = new Employee
            {
                BankBranchId = employee.BankBranchId,
                Name = employee.Name,
                Surname = employee.Surname,
                Patronymic = employee.Patronymic,
                Login = employee.Login,
                PasswordHash = hasher.HashPassword(employee.Password),
                Education = employee.Education,
                Gender = employee.Gender,
                DateBirth = employee.DateBirth,
                Position = employee.Position,
                Salary = employee.Salary,
            };

            await _employeeRepository.CreateAsync(employeeItem, token);
        }

        public async Task<EmployeeShowDto> LoginClientAsync(LoginDto dto, CancellationToken token)
        {
            var hasher = new PasswordHasher();

            var employee = await _employeeRepository.LoginEmployeeAsync(dto, token);

            if (employee != null)
            {
                if (hasher.VerifyHashedPassword(employee.PasswordHash, dto.Password))
                {
                    var employeeShowDto = _mapper.Map<EmployeeShowDto>(employee);

                    return employeeShowDto;
                }
                else
                    throw new Exception("Введите верный пароль");
            }
            else
                throw new Exception("Введите верный логин");
        }
    }
}
