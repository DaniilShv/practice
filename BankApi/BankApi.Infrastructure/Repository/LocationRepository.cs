using BankApi.Domain.Entities;
using BankApi.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BankApi.Infrastructure.Repository
{
    public class LocationRepository(BankDbContext _context) : ILocationRepository
    {
        public async Task CreateAsync(Location location, CancellationToken token)
        {
            await _context.Locations.AddAsync(location, token);
            await _context.SaveChangesAsync(token);
        }

        public async Task<List<Location>> GetAllAsync(CancellationToken token)
        {
            return await _context.Locations.ToListAsync(token);
        }

        public async Task<Location> GetById(Location entity, CancellationToken token)
        {
            return await _context.Locations.FirstOrDefaultAsync(x => x.Id == entity.Id, token);
        }

        public async Task RemoveAsync(Guid id, CancellationToken token)
        {
            await _context.Locations
                .Where(x => x.Id == id)
                .ExecuteDeleteAsync(token);

            await _context.SaveChangesAsync(token);
        }

        public async Task UpdateAsync(Location entity, CancellationToken token)
        {
            _context.Locations.Update(entity);

            await _context.SaveChangesAsync(token);
        }
    }
}
