using BankApi.Domain.Entities;
using BankApi.Domain.Interfaces;
using BankApi.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace BankApi.Infrastructure.Repository
{
    public class LocationRepository(BankDbContext _context) : ILocationRepository
    {
        /// <summary>
        /// Добавить информацию о местоположении в БД
        /// </summary>
        /// <param name="entity">Экземпляр объекта</param>
        /// <param name="token">Cancellation token</param>
        public async Task CreateAsync(Location location, CancellationToken token)
        {
            await _context.Locations.AddAsync(location, token);
            await _context.SaveChangesAsync(token);
        }

        /// <summary>
        /// Получить информацию о всех местоположениях банка из БД
        /// </summary>
        /// <param name="token">Cancellation token</param>
        /// <returns>Список объектов</returns>
        public async Task<List<Location>> GetAllAsync(CancellationToken token)
        {
            return await _context.Locations.ToListAsync(token);
        }

        /// <summary>
        /// Получить информацию о местоположении банка по ID из БД
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <param name="token">Cancellation token</param>
        /// <returns>Экземпляр объекта</returns>
        public async Task<Location> GetByIdAsync(Guid id, CancellationToken token)
        {
            var item = await _context.Locations.FirstOrDefaultAsync(x => x.Id == id, token);

            if (item == null)
                throw new ArgumentNullException("Город с таким ID не найден в базе данных банка");

            return item;
        }

        public DataTable GetDataTable()
        {
            return _context.Locations.ToDataTable();
        }

        public string GetTableName()
        {
            return "Locations";
        }

        /// <summary>
        /// Метод для удаления данных о местоположении банка из БД по ID
        /// </summary>
        /// <param name="id">Идентификатор объекта</param>
        /// <param name="token">Cancellation token</param>
        public async Task RemoveAsync(Guid id, CancellationToken token)
        {
            await _context.Locations
                .Where(x => x.Id == id)
                .ExecuteDeleteAsync(token);

            await _context.SaveChangesAsync(token);
        }

        /// <summary>
        /// Метод для обновления данных о местоположении банка в БД
        /// </summary>
        /// <param name="entity">Экземпляр объекта</param>
        /// <param name="token">Cancellation token</param>
        public async Task UpdateAsync(Location entity, CancellationToken token)
        {
            _context.Locations.Update(entity);

            await _context.SaveChangesAsync(token);
        }
    }
}
