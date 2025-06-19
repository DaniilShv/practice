namespace BankApi.Domain.Interfaces
{
    public interface IRepository<T>
    {
        /// <summary>
        /// Получить все объекты указанного типа из БД
        /// </summary>
        /// <param name="token">Cancellation token</param>
        /// <returns>Список объектов</returns>
        Task<List<T>> GetAllAsync(CancellationToken token);

        /// <summary>
        /// Получить объект указанного типа по ID из БД
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <param name="token">Cancellation token</param>
        /// <returns>Экземпляр объекта</returns>
        Task<T> GetByIdAsync(Guid id, CancellationToken token);

        /// <summary>
        /// Создать объект в БД
        /// </summary>
        /// <param name="entity">Экземпляр объекта</param>
        /// <param name="token">Cancellation token</param>
        Task CreateAsync(T entity, CancellationToken token);

        /// <summary>
        /// Метод для обновления данных объекта в БД
        /// </summary>
        /// <param name="entity">Экземпляр объекта</param>
        /// <param name="token">Cancellation token</param>
        Task UpdateAsync(T entity, CancellationToken token);

        /// <summary>
        /// Метод для удаления данных из БД по ID
        /// </summary>
        /// <param name="id">Идентификатор объекта</param>
        /// <param name="token">Cancellation token</param>
        Task RemoveAsync(Guid id, CancellationToken token);
    }
}
