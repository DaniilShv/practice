using BankApi.Domain.DTOs;
using BankApi.Domain.Entities;

namespace BankApi.Service.Interfaces
{
    public interface IBankCardService
    {
        Task CreateBankCardAsync(Guid bankRecordId, CancellationToken token);

        Task PayCardAsync(BankCardPayDto dto, CancellationToken token);

        Task<List<BankCard>> GetAllAsync(CancellationToken token);
    }
}
