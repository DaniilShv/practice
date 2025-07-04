﻿using BankApi.Domain.DTOs;
using BankApi.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BankApi.Controllers
{
    [ApiController]
    [Route("api/{v:apiversion}/[controller]")]
    [ApiVersion("1.0")]
    public class PaymentController(IPaymentService _paymentService) : ControllerBase
    {
        /// <summary>
        /// Информация о всех платежах с банковского счета по ID
        /// </summary>
        /// <param name="bankRecordId">ID банковского счета</param>
        /// <returns>Список платежей</returns>
        [HttpGet("GetPaymentByBankRecord/{bankRecordId}")]
        [Authorize(Policy = "User")]
        public async Task<List<PaymentHistoryShowDto>> GetPaymentByBankRecord(Guid bankRecordId)
        {
            return await _paymentService.GetByBankRecordAsync(bankRecordId, HttpContext.RequestAborted);
        }
    }
}
