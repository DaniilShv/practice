using BankApi.Domain.DTOs;
using BankApi.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BankApi.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/{v:apiversion}/[controller]")]
    public class CardsController(IBankCardService _bankCardService) : ControllerBase
    {
        [HttpPost("CreateBankCard/{bankRecordId}")]
        public async Task CreateBankCard(Guid bankRecordId)
        {
            await _bankCardService.CreateBankCardAsync(bankRecordId, HttpContext.RequestAborted);
        }

        [HttpPut("PayCard")]
        public async Task PayCard([FromQuery] BankCardPayDto dto, [FromQuery] string nameSeller)
        {
            await _bankCardService
                .PayCardAsync(dto, nameSeller, HttpContext.RequestAborted);
        }
    }
}
