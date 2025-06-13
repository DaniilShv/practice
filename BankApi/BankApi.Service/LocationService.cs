using BankApi.Domain.Entities;
using BankApi.Domain.Interfaces;
using BankApi.Service.Interfaces;

namespace BankApi.Service
{
    public class LocationService(ILocationRepository _locationRepository) : ILocationService
    {
        public async Task CreateLocationAsync(string name, CancellationToken token)
        {
            var location = new Location
            {
                Name = name
            };

            await _locationRepository.CreateAsync(location, token);
        }
    }
}
