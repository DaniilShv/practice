using BankApi.Domain.DTOs;
using BankApi.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BankApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ApiVersion("1.0")]
    public class PaymentController(IPaymentService _paymentService) : ControllerBase
    {
        [HttpGet("GetPaymentByBankRecord/{bankRecordId}")]
        public async Task<List<PaymentHistoryShowDto>> GetPaymentByBankRecord(Guid bankRecordId)
        {
            return await _paymentService.GetByBankRecordAsync(bankRecordId, HttpContext.RequestAborted);
        }
    }
}
