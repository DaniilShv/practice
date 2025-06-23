using BankApi.Domain.Entities;
using BankApi.Domain.Interfaces;
using BankApi.Service.Interfaces;

namespace BankApi.Service
{
    public class LocationService(ILocationRepository _locationRepository) : ILocationService
    {
        /// <summary>
        /// Запрос к repository на добавление города в БД
        /// </summary>
        /// <param name="name">Название города</param>
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
