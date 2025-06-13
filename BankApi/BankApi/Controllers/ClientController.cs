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
        [HttpPost("CreateClient")]
        [Authorize(Policy = "Employee")]
        public async Task CreateClient([FromBody] ClientCreateDto dto)
        {
            await _clientService.CreateClientAsync(dto, HttpContext.RequestAborted);
        }

        [HttpGet("GetClientBankRecords/{clientId}")]
        [Authorize(Policy = "User")]
        public async Task<List<BankRecordDto>> GetClientBankRecords(Guid clientId)
        {
            return await _clientService.GetBankRecordsAsync(clientId, HttpContext.RequestAborted);
        }

        [HttpGet("GetClientBankCards/{bankRecordId}")]
        [Authorize(Policy = "User")]
        public async Task<List<BankCardShowDto>> GetClientBankCards(Guid bankRecordId)
        {
            return await _clientService.GetAllBankCardsAsync(bankRecordId, HttpContext.RequestAborted);
        }

        [HttpPost("LoginClient")]
        public async Task<ClientShowDto> LoginClient([FromBody] LoginDto dto)
        {
            dto.RefreshToken = _tokenService.GenerateRefreshToken();

            var client = await _clientService.LoginClientAsync(dto, HttpContext.RequestAborted);

            var claims = _clientService.GetClaimClient(client);

            var token = _tokenService.GetToken(claims);

            HttpContext.Response.Cookies.Append("tasty_cookie", token);

            return client;
        }

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

        [HttpGet("test")]
        [Authorize(Policy = "User")]
        public async Task<IActionResult> Test()
        {
            return Ok();
        }

        [HttpGet("test2")]
        [Authorize(Policy = "UserDepositCredit")]
        public async Task<IActionResult> TestDeposit()
        {
            return Ok();
        }
    }
}
