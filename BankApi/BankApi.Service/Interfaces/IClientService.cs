namespace BankApi.Service.Interfaces
{
    public interface IClientService
    {
        Task CreateClientAsync(string surname, string name, string patronymic,
            ushort serialPassport, uint numberPassport, 
            string login, string password, CancellationToken token);
    }
}
