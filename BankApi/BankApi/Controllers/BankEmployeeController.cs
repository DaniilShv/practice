using BankApi.Domain.DTOs;
using BankApi.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BankApi.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/{v:apiversion}/[controller]")]
    public class BankEmployeeController(IEmployeeService _employeeService) : ControllerBase
    {
        [HttpPost("CreateEmployee")]
        [Authorize(Policy = "Manager")]
        public async Task CreateEmployee([FromBody] CreateEmployeeDto employee)
        {
            await _employeeService.CreateEmployeeAsync(employee, HttpContext.RequestAborted);
        }

        [HttpPost("LoginEmployee")]
        public async Task<EmployeeShowDto> LoginEmployee([FromBody] LoginDto dto)
        {
            return await _employeeService.LoginClientAsync(dto, HttpContext.RequestAborted);
        }
    }
}
