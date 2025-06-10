namespace BankApi.Service.Interfaces
{
    public interface IBankBranchService
    {
        Task CreateBankBranchAsync(Guid locationId, string address, CancellationToken token);
    }
}
