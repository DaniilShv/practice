using BankApi.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BankApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CardsController(IBankCardService _bankCardService) : ControllerBase
    {
        [HttpPost("CreateBankCard/{bankRecordId}")]
        public async Task CreateBankCard(Guid bankRecordId)
        {
            await _bankCardService.CreateBankCardAsync(bankRecordId, HttpContext.RequestAborted);
        }

        [HttpPut("PayCard")]
        public async Task PayCard([FromQuery]Guid cardId, [FromQuery]decimal sum,
            [FromQuery]string nameSeller)
        {
            await _bankCardService
                .PayCardAsync(cardId, sum, nameSeller, HttpContext.RequestAborted);
        }
    }
}
