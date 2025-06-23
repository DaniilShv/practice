using BankApi.Domain.Entities;

namespace BankApi.Service.Interfaces
{
    public interface ILocationService
    {
        Task CreateLocationAsync(string name, CancellationToken token);

        Task<List<Location>> GetAllAsync(CancellationToken token);
    }
}
