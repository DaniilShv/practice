namespace BankApi.Service.Interfaces
{
    public interface ILocationService
    {
        Task CreateLocationAsync(string name, CancellationToken token);
    }
}
