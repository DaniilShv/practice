using BankApi.Domain.DTOs;
using BankApi.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BankApi.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/{v:apiversion}/[controller]")]
    public class CardsController(IBankCardService _bankCardService) : ControllerBase
    {
        /// <summary>
        /// Добавить информацию о банковской карте в БД
        /// </summary>
        /// <param name="bankRecordId">ID банковского счета</param>
        [HttpPost("CreateBankCard/{bankRecordId}")]
        [Authorize(Policy = "Employee")]
        public async Task CreateBankCard(Guid bankRecordId)
        {
            await _bankCardService.CreateBankCardAsync(bankRecordId, HttpContext.RequestAborted);
        }

        /// <summary>
        /// Оплатить банковской картой
        /// </summary>
        /// <param name="dto">Информация о банковской карте</param>
        /// <param name="nameSeller">Название продавца</param>
        [HttpPut("PayCard")]
        [Authorize(Policy = "User")]
        public async Task PayCard([FromQuery] BankCardPayDto dto, [FromQuery] string nameSeller)
        {
            if (nameSeller == null || nameSeller.Length == 0)
                throw new ArgumentNullException("Укажите корректное название получателя");

            await _bankCardService
                .PayCardAsync(dto, nameSeller, HttpContext.RequestAborted);
        }
    }
}
