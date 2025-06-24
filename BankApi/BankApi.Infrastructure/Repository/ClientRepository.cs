using BankApi.Domain.DTOs;
using BankApi.Domain.Entities;
using BankApi.Domain.Interfaces;
using BankApi.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace BankApi.Infrastructure.Repository
{
    public class ClientRepository(BankDbContext _context) : IClientRepository
    {
        /// <summary>
        /// Создать объект клиента в БД
        /// </summary>
        /// <param name="entity">Экземпляр объекта</param>
        /// <param name="token">Cancellation token</param>
        public async Task CreateAsync(Client client, CancellationToken token)
        {
            await _context.Clients.AddAsync(client, token);

            await _context.SaveChangesAsync(token);
        }

        /// <summary>
        /// Получить всех клиентов из БД
        /// </summary>
        /// <param name="token">Cancellation token</param>
        /// <returns>Список объектов</returns>
        public async Task<List<Client>> GetAllAsync(CancellationToken token)
        {
            return await _context.Clients.ToListAsync(token);
        }

        /// <summary>
        /// Информация обо всех банковских картах клиента (по ID банковского счета)
        /// </summary>
        /// <param name="bankRecordId">ID банковского счета</param>
        /// <param name="token">Cancellation token</param>
        /// <returns>Список банковских карт клиента</returns>
        public async Task<List<BankCardShowDto>> GetAllBankCardsAsync(Guid bankRecordId, CancellationToken token)
        {
            return await _context.BankCards
                .Where(x => x.BankRecordId == bankRecordId)
                .Select(x => new BankCardShowDto { CardNumber = x.CardNumber, CvvCode = x.CvvCode, Date = x.Date })
                .AsNoTracking()
                .ToListAsync(token);
        }

        /// <summary>
        /// Информация обо всех банковских счетах клиента
        /// </summary>
        /// <param name="clientId">ID клиента банка</param>
        /// <param name="token">Cancellation token</param>
        /// <returns>Список банковских счетов клиента</returns>
        public async Task<List<BankRecordDto>> GetAllBankRecordsAsync(Guid clientId, CancellationToken token)
        {
            return await _context.BankRecords
                .Where(x => x.ClientId == clientId)
                .Select(x => new BankRecordDto { Id = x.Id, Total = x.Total})
                .AsNoTracking()
                .ToListAsync(token);
        }

        /// <summary>
        /// Получить информацию о клиенте по ID из БД
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <param name="token">Cancellation token</param>
        /// <returns>Экземпляр объекта</returns>
        public async Task<Client> GetByIdAsync(Guid id, CancellationToken token)
        {
            var client = await _context.Clients.FirstOrDefaultAsync(x => x.Id == id, token);

            if (client == null)
                throw new ArgumentNullException("Клиент банка с таким ID не найден в базе данных банка");

            return client;
        }

        /// <summary>
        /// Информация о клиенте по refresh token
        /// </summary>
        /// <param name="refreshToken">refresh token</param>
        /// <param name="token">Cancellation token</param>
        /// <returns>Экземпляр CLient</returns>
        public async Task<Client> GetByRefreshTokenAsync(string refreshToken, CancellationToken token)
        {
            var item = await _context.Clients.FirstOrDefaultAsync(x => x.RefreshToken == refreshToken);

            return item;
        }

        public DataTable GetDataTable()
        {
            return _context.Clients
                .Select(x => new
                {
                    Id = x.Id,
                    Surname = x.Surname,
                    Name = x.Name,
                    Patronymic = x.Patronymic,
                    DateBirth = x.DateBirth,
                    SerialPassport = x.SerialPassport,
                    NumberPassport = x.NumberPassport,
                    Login = x.Login,
                    PasswordHash = x.PasswordHash
                })
                .ToDataTable();
        }

        public string GetTableName()
        {
            return "Clients";
        }

        /// <summary>
        /// Информация о клиенте по логину
        /// </summary>
        /// <param name="dto">Экземпляр LoginDto</param>
        /// <param name="token">Cancellation token</param>
        /// <returns>экземпляр Client</returns>
        public async Task<Client> LoginClientAsync(LoginDto dto, CancellationToken token)
        {
            var client = await _context.Clients.FirstOrDefaultAsync(x => x.Login == dto.Login);

            return client;
        }

        /// <summary>
        /// Метод для удаления данных о клиенте из БД по ID
        /// </summary>
        /// <param name="id">Идентификатор объекта</param>
        /// <param name="token">Cancellation token</param>
        public async Task RemoveAsync(Guid id, CancellationToken token)
        {
            await _context.Clients
                .Where(x => x.Id == id)
                .ExecuteDeleteAsync(token);

            await _context.SaveChangesAsync(token);
        }

        /// <summary>
        /// Метод для обновления данных клиента в БД
        /// </summary>
        /// <param name="entity">Экземпляр объекта</param>
        /// <param name="token">Cancellation token</param>
        public async Task UpdateAsync(Client entity, CancellationToken token)
        {
            _context.Clients.Update(entity);

            await _context.SaveChangesAsync(token);
        }
    }
}
