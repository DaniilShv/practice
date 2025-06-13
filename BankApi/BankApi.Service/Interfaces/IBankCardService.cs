using BankApi.Domain.DTOs;

namespace BankApi.Service.Interfaces
{
    public interface IBankCardService
    {
        Task CreateBankCardAsync(Guid bankRecordId, CancellationToken token);

        Task PayCardAsync(BankCardPayDto dto, string nameSeller, CancellationToken token);
    }
}
