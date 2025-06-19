namespace BankApi.Service.Interfaces
{
    public interface ILocationService
    {
        /// <summary>
        /// Запрос к repository на добавление города в БД
        /// </summary>
        /// <param name="name">Название города</param>
        Task CreateLocationAsync(string name, CancellationToken token);
    }
}
