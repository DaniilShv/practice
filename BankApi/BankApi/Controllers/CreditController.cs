using BankApi.Domain.DTOs;
using BankApi.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BankApi.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/{v:apiversion}/[controller]")]
    public class CreditController(IClientCreditService _clientCreditService) : ControllerBase
    {
        [HttpPost("CreateCredit")]
        [Authorize(Policy = "UserDepositCredit")]
        public async Task CreateCredit([FromBody] ClientCreditCreateDto credit)
        {
            await _clientCreditService.CreateCreditAsync(credit, HttpContext.RequestAborted);
        }

        [HttpDelete("RemoveCredit")]
        [Authorize(Policy = "UserDepositCredit")]
        public async Task RemoveCredit([FromBody] Guid clientId, [FromBody] Guid creditId)
        {
            await _clientCreditService.RemoveCreditAsync(clientId, creditId, HttpContext.RequestAborted);
        }
    }
}
