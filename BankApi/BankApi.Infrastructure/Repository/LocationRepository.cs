using BankApi.Domain;
using BankApi.Infrastructure.Interfaces;

namespace BankApi.Infrastructure.Repository
{
    public class LocationRepository(BankDbContext _context) : ILocationRepository
    {
        public async Task CreateLocationAsync(Location location, CancellationToken token)
        {
            await _context.Locations.AddAsync(location, token);
            await _context.SaveChangesAsync(token);
        }
    }
}
