using BankApi.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BankApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DepositeController(IClientDepositsService _clientDepositsService) : ControllerBase
    {
        [HttpPost("CreateDeposit/{clientId}/{depositId}/{total}/{dist}/{percent}/{type}")]
        public async Task CreateDeposit(Guid clientId, Guid depositId, decimal total,
            int dist, double percent, int type)
        {
            await _clientDepositsService.CreateDepositAsync(clientId, depositId, total,
                dist, percent, type, HttpContext.RequestAborted);
        }
    }
}
