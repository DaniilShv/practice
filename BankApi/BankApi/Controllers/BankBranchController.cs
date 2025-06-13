using BankApi.Domain.DTOs;
using BankApi.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BankApi.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/{v:apiversion}/[controller]")]
    public class BankBranchController(ILocationService _locationService,
        IBankBranchService _bankBranchService) : ControllerBase
    {
        [HttpPost("CreateLocation/{name}")]
        public async Task CreateLocation(string name)
        {
            await _locationService.CreateLocationAsync(name, HttpContext.RequestAborted);
        }

        [HttpPost("CreateBankBranch")]
        public async Task CreateBankBranch([FromBody] BankBranchCreateDto dto)
        {
            await _bankBranchService.CreateBankBranchAsync(dto, HttpContext.RequestAborted);
        }
    }
}
