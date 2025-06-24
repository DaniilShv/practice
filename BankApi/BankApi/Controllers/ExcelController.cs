using BankApi.Domain.Interfaces;
using BankApi.Service.Interfaces;
using BankApi.Service.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BankApi.Controllers
{
    [ApiController]
    [Route("api/{v:apiversion}/[controller]")]
    [ApiVersion("1.0")]
    [Authorize(Policy = "Manager")]
    public class ExcelController(IServiceProvider _provider) : ControllerBase
    {
        const string _connStr = "ExcelDb.xlsx";

        /// <summary>
        /// Создает Excel документ с соедржимым базы данных
        /// </summary>
        [HttpGet("CreateExcelFile")]
        public IActionResult CreateExcelFile()
        {
            var services = _provider.GetServices<IExcelRepository>();

            ExcelService.CreateExcelDoc(services, _connStr);

            return Ok();
        }
    }
}
