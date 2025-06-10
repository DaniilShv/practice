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
    }
}
