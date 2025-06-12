using BankApi.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BankApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BankRecordsController(IBankRecordService _bankRecordService) : ControllerBase
    {
        [HttpPost("CreateBankRecord/{clientId}/{bankBranchId}")]
        public async Task CreateBankRecord(Guid clientId, Guid bankBranchId)
        {
            await _bankRecordService.CreateBankRecordAsync(clientId, bankBranchId, HttpContext.RequestAborted);
        }

        [HttpPut("DepositMoneyOnRecord/{bankRecordId}/{total}")]
        public async Task DepositMoneyOnRecord(Guid bankRecordId, decimal total)
        {
            await _bankRecordService.DepositMoneyOnRecord(bankRecordId, total, HttpContext.RequestAborted);
        }

        [HttpPut("WithdrawalMoneyOnRecord/{bankRecordId}/{sum}")]
        public async Task WithdrawalMoneyOnRecord(Guid bankRecordId, decimal sum)
        {
            await _bankRecordService.WithdrawalMoneyOnRecordAsync(bankRecordId, sum, HttpContext.RequestAborted);
        }
    }
}
