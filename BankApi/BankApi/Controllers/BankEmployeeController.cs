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
        /// <summary>
        /// Добавить сотрудника в БД
        /// </summary>
        /// <param name="employee">Информация о сотруднике</param>
        [HttpPost("CreateEmployee")]
        [Authorize(Policy = "Manager")]
        public async Task CreateEmployee([FromBody] CreateEmployeeDto employee)
        {
            await _employeeService.CreateEmployeeAsync(employee, HttpContext.RequestAborted);
        }

        /// <summary>
        /// Вход сотрудника в систему
        /// </summary>
        /// <param name="dto">Логин и пароль</param>
        /// <returns>Информация о сотруднике</returns>
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

        /// <summary>
        /// Проверяет refresh token сотрудника
        /// </summary>
        /// <param name="dto">Информация о токенах</param>
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

        /// <summary>
        /// Обновление должности сотрудника
        /// </summary>
        /// <param name="id">ID сотрудника</param>
        /// <param name="position">Название должности</param>
        [HttpPut("UpdatePositionEmployee/{id}/{position}")]
        public async Task UpdatePositionEmployee(Guid id, string position)
        {
            await _employeeService.UpdatePositionEmployeeAsync(id, position, HttpContext.RequestAborted);
        }

        /// <summary>
        /// Удалить информацию о сотруднике из БД по ID
        /// </summary>
        /// <param name="id">ID сотрудника</param>
        [HttpDelete("RemoveEmployee/{id}")]
        public async Task RemoveEmployee(Guid id)
        {
            await _employeeService.RemoveEmployeeAsync(id, HttpContext.RequestAborted);
        }
    }
}
