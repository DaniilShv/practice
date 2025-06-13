using BankApi.Domain.DTOs;
using BankApi.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BankApi.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/{v:apiversion}/[controller]")]
    public class CreditController(IClientCreditService _clientCreditService) : ControllerBase
    {
        [HttpPost("CreateCredit")]
        public async Task CreateCredit([FromBody] ClientCreditCreateDto credit)
        {
            await _clientCreditService.CreateCreditAsync(credit, HttpContext.RequestAborted);
        }

        [HttpDelete("RemoveCredit")]
        public async Task RemoveCredit([FromBody] ClientCreditRemoveDto credit)
        {
            await _clientCreditService.RemoveCreditAsync(credit, HttpContext.RequestAborted);
        }
    }
}
