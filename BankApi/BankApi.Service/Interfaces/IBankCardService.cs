namespace BankApi.Service.Interfaces
{
    public interface IBankCardService
    {
        Task CreateBankCardAsync(Guid bankRecordId, CancellationToken token);
    }
}
