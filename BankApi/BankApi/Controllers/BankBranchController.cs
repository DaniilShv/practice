using BankApi.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BankApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BankBranchController(ILocationService _locationService,
        IBankBranchService _bankBranchService) : ControllerBase
    {
        [HttpPost("CreateLocation/{name}")]
        public async Task CreateLocation(string name)
        {
            await _locationService.CreateLocationAsync(name, HttpContext.RequestAborted);
        }

        [HttpPost("CreateBankBranch/{locationId}/{adress}")]
        public async Task CreateBankBranch(Guid locationId, string adress)
        {
            await _bankBranchService.CreateBankBranchAsync(locationId, 
                adress, HttpContext.RequestAborted);
        }
    }
}
