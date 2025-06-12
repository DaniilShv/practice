using BankApi.Domain.DTOs;
using BankApi.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BankApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController(IClientService _clientService) : ControllerBase
    {
        [HttpPost("CreateClientAsync/{surname}/{name}/{patronymic}/{serialPassport}/{numberPassport}/{login}/{password}")]
        public async Task CreateClientAsync(string surname, string name, string patronymic,
            ushort serialPassport, uint numberPassport,
            string login, string password)
        {
            await _clientService.CreateClientAsync(surname, name, patronymic, serialPassport,
                numberPassport, login, password, HttpContext.RequestAborted);
        }

        [HttpGet("GetClientBankRecordsAsync/{clientId}")]
        public async Task<List<BankRecordDto>> GetClientBankRecordsAsync(Guid clientId)
        {
            return await _clientService.GetBankRecordsAsync(clientId, HttpContext.RequestAborted);
        }

        [HttpGet("GetClientBankCards/{bankRecordId}")]
        public async Task<List<BankCardDto>> GetClientBankCards(Guid bankRecordId)
        {
            return await _clientService.GetAllBankCardsAsync(bankRecordId, HttpContext.RequestAborted);
        }
    }
}
