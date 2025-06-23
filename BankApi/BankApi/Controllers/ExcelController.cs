using BankApi.Service.Interfaces;
using BankApi.Service.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BankApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ApiVersion("1.0")]
    [Authorize(Policy = "Manager")]
    public class ExcelController(IClientService _clientService, 
        IBankBranchService _bankBranchService, IBankCardService _bankCardService,
        IClientCreditService _clientCreditService, IClientDepositsService _clientDepositsService,
        IEmployeeService _employeeService, ILocationService _locationService,
        IPaymentService _paymentService, IBankRecordService _bankRecordService) : ControllerBase
    {
        const string _connStr = "ExcelDb.xlsx";

        /// <summary>
        /// Создает Excel документ с соедржимым базы данных
        /// </summary>
        [HttpGet("CreateExcelFile")]
        public async Task<IActionResult> CreateExcelFile()
        {
            var bankBranches = await _bankBranchService.GetAllAsync(HttpContext.RequestAborted);
            var bankCards = await _bankCardService.GetAllAsync(HttpContext.RequestAborted);
            var bankRecords = await _bankRecordService.GetAllAsync(HttpContext.RequestAborted);
            var clientCredits = await _clientCreditService.GetAllAsync(HttpContext.RequestAborted);
            var clientDeposits = await _clientDepositsService.GetAllAsync(HttpContext.RequestAborted);
            var clients = await _clientService.GetAllAsync(HttpContext.RequestAborted);
            var employees = await _employeeService.GetAllAsync(HttpContext.RequestAborted);
            var locations = await _locationService.GetAllAsync(HttpContext.RequestAborted);
            var payments = await _paymentService.GetAllAsync(HttpContext.RequestAborted);

            ExcelService.CreateExcelDoc(clients, _connStr, "Clients");
            ExcelService.CreateExcelDoc(bankBranches, _connStr, "BankBranches");
            ExcelService.CreateExcelDoc(bankCards, _connStr, "BankCards");
            ExcelService.CreateExcelDoc(bankRecords, _connStr, "BankRecords");
            ExcelService.CreateExcelDoc(clientCredits, _connStr, "ClientCredits");
            ExcelService.CreateExcelDoc(clientDeposits, _connStr, "ClientDeposits");
            ExcelService.CreateExcelDoc(employees, _connStr, "Employees");
            ExcelService.CreateExcelDoc(locations, _connStr, "Locations");
            ExcelService.CreateExcelDoc(payments, _connStr, "Payments");

            return Ok();
        }
    }
}
