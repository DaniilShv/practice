using System.Data;

namespace BankApi.Domain.Interfaces
{
    public interface IRepository<T>
    {
        Task<List<T>> GetAllAsync(CancellationToken token);

        Task CreateAsync(T entity, CancellationToken token);

        Task UpdateAsync(T entity, CancellationToken token);

        Task<T> GetByIdAsync(Guid id, CancellationToken token);

        Task RemoveAsync(Guid id, CancellationToken token);
    }
}
