namespace BankApi.Service.Interfaces
{
    public interface IBankCardService
    {
        Task CreateBankCardAsync(Guid bankRecordId, CancellationToken token);

        Task PayCardAsync(Guid cardId, decimal sum, string nameSeller, CancellationToken token);
    }
}
