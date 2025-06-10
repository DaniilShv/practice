using BankApi.Domain;

namespace BankApi.Infrastructure.Interfaces
{
    public interface ILocationRepository
    {
        Task CreateLocationAsync(Location location, CancellationToken token);
    }
}
