using BankApi.Domain.DTOs;
using BankApi.Domain.Entities;
using BankApi.Domain.Enums;
using BankApi.Service;
using BankApi.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BankApi.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/{v:apiversion}/[controller]")]
    public class BankEmployeeController(IEmployeeService _employeeService,
        ITokenService _tokenService) : ControllerBase
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
            string refreshToken = _tokenService.GenerateRefreshToken();

            var employee = await _employeeService.LoginEmployeeAsync(dto, refreshToken, HttpContext.RequestAborted);

            var claims = _employeeService.GetClaimEmployee(employee);

            var token = _tokenService.GetToken(claims);

            HttpContext.Response.Cookies.Append("tasty_cookie", token);

            return employee;
        }

        [HttpPut("RefreshTokenEmployee")]
        public IActionResult RefreshTokenEmployee([FromBody] TokenDto dto)
        {
            var client = _employeeService.GetByRefreshTokenAsync(dto.RefreshToken, HttpContext.RequestAborted);

            if (client == null)
                return BadRequest("Enter correct refresh Token");

            var claims = _tokenService.GetPrincipalFromExpiredToken(dto.Token);

            var token = _tokenService.GetToken(claims.Claims);

            HttpContext.Response.Cookies.Append("tasty_cookie", token);

            return Ok();
        }

        [HttpPut("UpdatePositionEmployee/{id}/{position}")]
        public async Task UpdatePositionEmployee(Guid id, string position)
        {
            await _employeeService.UpdatePositionEmployeeAsync(id, position, HttpContext.RequestAborted);
        }

        [HttpDelete("RemoveEmployee/{id}")]
        public async Task RemoveEmployee(Guid id)
        {
            await _employeeService.RemoveEmployeeAsync(id, HttpContext.RequestAborted);
        }
    }
}
