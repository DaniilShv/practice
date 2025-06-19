using BankApi.Domain.DTOs;
using BankApi.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BankApi.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/{v:apiversion}/[controller]")]
    public class DepositController(IClientDepositsService _clientDepositsService) : ControllerBase
    {
        /// <summary>
        /// Открыть банковский вклад
        /// </summary>
        /// <param name="dto">Информация о вкладе и клиенте</param>
        [HttpPost("CreateDeposit")]
        [Authorize(Policy = "UserDepositCredit")]
        public async Task CreateDeposit([FromBody] ClientDepositCreateDto dto)
        {
            await _clientDepositsService.CreateDepositAsync(dto, HttpContext.RequestAborted);
        }

        /// <summary>
        /// Положить деньги на вклад с банковского счета
        /// </summary>
        /// <param name="dto">Информация о денежном перевод</param>
        [HttpPut("TransferMoneyOnDeposit")]
        [Authorize(Policy = "UserDepositCredit")]
        public async Task TransferMoneyOnDeposit([FromBody] TransferMoneyDepositDto dto)
        {
            await _clientDepositsService.TransferMoneyOnDepositAsync(dto, HttpContext.RequestAborted);
        }

        /// <summary>
        /// Положить деньги на банковский счет со вклада
        /// </summary>
        /// <param name="dto">Информация о денежном переводе</param>
        [HttpPut("TransferMoneyFromDeposit")]
        [Authorize(Policy = "UserDepositCredit")]
        public async Task TransferMoneyFromDeposit([FromBody] TransferMoneyDepositDto dto)
        {
            await _clientDepositsService.TransferMoneyFromDepositAsync(dto, HttpContext.RequestAborted);
        }
    }
}
