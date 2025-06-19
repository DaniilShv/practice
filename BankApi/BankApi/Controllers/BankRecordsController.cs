using BankApi.Domain.DTOs;
using BankApi.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BankApi.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/{v:apiversion}/[controller]")]
    public class BankRecordsController(IBankRecordService _bankRecordService) : ControllerBase
    {
        /// <summary>
        /// Открыть банковский счет
        /// </summary>
        /// <param name="dto">Кому и каким отделением открыт счет</param>
        [HttpPost("CreateBankRecord")]
        [Authorize(Policy = "Employee")]
        public async Task CreateBankRecord([FromBody] BankRecordCreateDto dto)
        {
            await _bankRecordService.CreateBankRecordAsync(dto, HttpContext.RequestAborted);
        }

        /// <summary>
        /// Положить деньги на банковский счет
        /// </summary>
        /// <param name="dto">ID счета и сумма</param>
        [HttpPut("DepositMoneyOnRecord")]
        [Authorize(Policy = "UserDepositCredit")]
        public async Task DepositMoneyOnRecord([FromBody] DepositBankRecordDto dto)
        {
            await _bankRecordService.DepositMoneyOnRecord(dto, HttpContext.RequestAborted);
        }

        /// <summary>
        /// Взять деньги с банковского счета
        /// </summary>
        /// <param name="dto">ID счета и сумма</param>
        [HttpPut("WithdrawalMoneyOnRecord")]
        [Authorize(Policy = "UserDepositCredit")]
        public async Task WithdrawalMoneyOnRecord([FromBody] WithdrawalBankRecordDto dto)
        {
            await _bankRecordService.WithdrawalMoneyOnRecordAsync(dto, HttpContext.RequestAborted);
        }
    }
}
