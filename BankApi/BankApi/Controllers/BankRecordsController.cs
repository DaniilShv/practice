using BankApi.Domain.DTOs;
using BankApi.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BankApi.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/{v:apiversion}/[controller]")]
    public class BankRecordsController(IBankRecordService _bankRecordService) : ControllerBase
    {
        [HttpPost("CreateBankRecord/{clientId}/{bankBranchId}")]
        public async Task CreateBankRecord([FromBody] BankRecordCreateDto dto)
        {
            await _bankRecordService.CreateBankRecordAsync(dto, HttpContext.RequestAborted);
        }

        [HttpPut("DepositMoneyOnRecord")]
        public async Task DepositMoneyOnRecord([FromBody] DepositBankRecordDto dto)
        {
            await _bankRecordService.DepositMoneyOnRecord(dto, HttpContext.RequestAborted);
        }

        [HttpPut("WithdrawalMoneyOnRecord")]
        public async Task WithdrawalMoneyOnRecord([FromBody] WithdrawalBankRecordDto dto)
        {
            await _bankRecordService.WithdrawalMoneyOnRecordAsync(dto, HttpContext.RequestAborted);
        }
    }
}
