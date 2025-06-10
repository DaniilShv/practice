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
    }
}
