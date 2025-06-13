namespace BankApi.Domain.Interfaces
{
    public interface IRepository<T>
    {
        Task<List<T>> GetAllAsync(CancellationToken token);

        Task<T> GetById(T entity, CancellationToken token);

        Task CreateAsync(T entity, CancellationToken token);

        Task UpdateAsync(T entity, CancellationToken token);

        Task RemoveAsync(T entity, CancellationToken token);
    }
}
