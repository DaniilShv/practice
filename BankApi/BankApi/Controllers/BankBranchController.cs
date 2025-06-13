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
        [HttpPost("CreateBankBranchLocation/{name}")]
        [Authorize(Policy = "Manager")]
        public async Task CreateLocation(string name)
        {
            if (name == null || name.Length == 0)
                throw new ArgumentNullException("Введите название города корректно");

            await _locationService.CreateLocationAsync(name, HttpContext.RequestAborted);
        }

        [HttpPost("CreateBankBranch")]
        [Authorize(Policy = "Manager")]
        public async Task CreateBankBranch([FromBody] BankBranchCreateDto dto)
        {
            await _bankBranchService.CreateBankBranchAsync(dto, HttpContext.RequestAborted);
        }
    }
}
