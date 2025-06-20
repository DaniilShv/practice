using BankApi.Domain.DTOs;
using BankApi.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BankApi.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/{v:apiversion}/[controller]")]
    public class ClientController(IClientService _clientService,
        ITokenService _tokenService) : ControllerBase
    {
        /// <summary>
        /// Добавить клиента банка в БД
        /// </summary>
        /// <param name="dto">Информация о клиенте банка</param>
        [HttpPost("CreateClient")]
        [Authorize(Policy = "Employee")]
        public async Task CreateClient([FromBody] ClientCreateDto dto)
        {
            await _clientService.CreateClientAsync(dto, HttpContext.RequestAborted);
        }

        /// <summary>
        /// Информация о банковских счетах клиента
        /// </summary>
        /// <param name="clientId">ID клиента</param>
        /// <returns>Список информации о банковских счетах</returns>
        [HttpGet("GetClientBankRecords/{clientId}")]
        [Authorize(Policy = "User")]
        public async Task<List<BankRecordDto>> GetClientBankRecords(Guid clientId)
        {
            return await _clientService.GetBankRecordsAsync(clientId, HttpContext.RequestAborted);
        }

        /// <summary>
        /// Информация о банковских картах клиента по ID банковского счета
        /// </summary>
        /// <param name="bankRecordId">ID банковского счета</param>
        /// <returns>Список информации о банковских картах</returns>
        [HttpGet("GetClientBankCards/{bankRecordId}")]
        [Authorize(Policy = "User")]
        public async Task<List<BankCardShowDto>> GetClientBankCards(Guid bankRecordId)
        {
            return await _clientService.GetAllBankCardsAsync(bankRecordId, HttpContext.RequestAborted);
        }

        /// <summary>
        /// Авторизация клиента банка в системе
        /// </summary>
        /// <param name="dto">Логин и пароль</param>
        /// <returns>Клиент банка</returns>
        [HttpPost("LoginClient")]
        public async Task<ClientShowDto> LoginClient([FromBody] LoginDto dto)
        {
            string refreshToken = _tokenService.GenerateRefreshToken();

            var client = await _clientService.LoginClientAsync(dto, refreshToken, HttpContext.RequestAborted);

            var claims = _clientService.GetClaimClient(client);

            var token = _tokenService.GetToken(claims);

            HttpContext.Response.Cookies.Append("tasty_cookie", token);

            return client;
        }

        /// <summary>
        /// Проверяет refresh token клиента банка
        /// </summary>
        /// <param name="dto">Информация о токенах</param>
        [HttpPut("RefreshTokenClient")]
        public IActionResult RefreshTokenClient([FromBody] TokenDto dto)
        {
            var client = _clientService.GetByRefreshTokenAsync(dto.RefreshToken, HttpContext.RequestAborted);

            if (client == null)
                return BadRequest("Enter correct refresh Token");

            var claims = _tokenService.GetPrincipalFromExpiredToken(dto.Token);

            var token = _tokenService.GetToken(claims.Claims);

            HttpContext.Response.Cookies.Append("tasty_cookie", token);

            return Ok();
        }

        /// <summary>
        /// Удалить информация о клиенте из БД
        /// </summary>
        /// <param name="id">ID клиента</param>
        [HttpDelete("RemoveClient/{id}")]
        [Authorize(Policy = "Employee")]
        public async Task RemoveClient(Guid id)
        {
            await _clientService.RemoveClientAsync(id, HttpContext.RequestAborted);
        }
    }
}
