using BankApi.Domain.Entities;
using BankApi.Domain.Interfaces;
using BankApi.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace BankApi.Infrastructure.Repository
{
    public class BankBranchRepository(BankDbContext _context) : IBankBranchRepository
    {
        /// <summary>
        /// Создать банковское отделение в БД
        /// </summary>
        /// <param name="entity">Экземпляр объекта</param>
        /// <param name="token">Cancellation token</param>
        public async Task CreateAsync(BankBranch bankBranch, CancellationToken token)
        {
            await _context.BankBranches.AddAsync(bankBranch, token);

            await _context.SaveChangesAsync(token);
        }

        /// <summary>
        /// Получить все банковские отделения из БД
        /// </summary>
        /// <param name="token">Cancellation token</param>
        /// <returns>Список объектов</returns>
        public async Task<List<BankBranch>> GetAllAsync(CancellationToken token)
        {
            return await _context.BankBranches.ToListAsync(token);
        }

        /// <summary>
        /// Получить экземпляр банковского отделения по ID из БД
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <param name="token">Cancellation token</param>
        /// <returns>Экземпляр объекта</returns>
        public async Task<BankBranch> GetByIdAsync(Guid id, CancellationToken token)
        {
            var item = await _context.BankBranches.FirstOrDefaultAsync(x => x.Id == id, token);

            if (item == null)
                throw new ArgumentNullException("Банковское отделение с таким ID не найден в базе данных банка");

            return item;
        }

        public DataTable GetDataTable()
        {
            return _context.BankBranches.Select(x => new { 
                Id = x.Id,
                LocationId = x.LocationId,
                Adress = x.Adress
            }).ToDataTable();
        }

        public string GetTableName()
        {
            return "BankBranches";
        }

        /// <summary>
        /// Метод для удаления данных о банковском отделении из БД по ID
        /// </summary>
        /// <param name="id">Идентификатор объекта</param>
        /// <param name="token">Cancellation token</param>
        public async Task RemoveAsync(Guid id, CancellationToken token)
        {
            await _context.BankBranches
                .Where(x => x.Id == id)
                .ExecuteDeleteAsync(token);

            await _context.SaveChangesAsync(token);
        }

        /// <summary>
        /// Метод для обновления данных объекта в БД
        /// </summary>
        /// <param name="entity">Экземпляр объекта</param>
        /// <param name="token">Cancellation token</param>
        public async Task UpdateAsync(BankBranch entity, CancellationToken token)
        {
            _context.BankBranches.Update(entity);

            await _context.SaveChangesAsync(token);
        }
    }
}
