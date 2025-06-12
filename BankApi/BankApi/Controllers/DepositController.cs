using BankApi.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BankApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DepositController(IClientDepositsService _clientDepositsService) : ControllerBase
    {
        [HttpPost("CreateDeposit/{clientId}/{depositId}/{total}/{dist}/{percent}/{type}")]
        public async Task CreateDeposit(Guid clientId, Guid depositId, decimal total,
            int dist, double percent, int type)
        {
            await _clientDepositsService.CreateDepositAsync(clientId, depositId, total,
                dist, percent, type, HttpContext.RequestAborted);
        }

        [HttpPut("TransferMoneyOnDeposit/{bankRecordId}/{clientId}/{depositId}/{sum}")]
        public async Task TransferMoneyOnDeposit(Guid bankRecordId, Guid clientId, 
            Guid depositId, decimal sum)
        {
            await _clientDepositsService.TransferMoneyOnDepositAsync(bankRecordId, clientId,
                depositId, sum, HttpContext.RequestAborted);
        }

        [HttpPut("TransferMoneyFromDeposit/{bankRecordId}/{clientId}/{depositId}/{sum}")]
        public async Task TransferMoneyFromDeposit(Guid bankRecordId, Guid clientId,
            Guid depositId, decimal sum)
        {
            await _clientDepositsService.TransferMoneyFromDepositAsync(bankRecordId, clientId,
                depositId, sum, HttpContext.RequestAborted);
        }
    }
}
