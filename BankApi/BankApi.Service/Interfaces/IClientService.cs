using BankApi.Domain;
using BankApi.Domain.DTOs;

namespace BankApi.Service.Interfaces
{
    public interface IClientService
    {
        Task CreateClientAsync(string surname, string name, string patronymic,
            ushort serialPassport, uint numberPassport, 
            string login, string password, CancellationToken token);

        Task<List<BankRecordDto>> GetBankRecordsAsync(Guid clientId, CancellationToken token);

        Task<List<BankCardDto>> GetAllBankCardsAsync(Guid bankRecordId, CancellationToken token);
    }
}
