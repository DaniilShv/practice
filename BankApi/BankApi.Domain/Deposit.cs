namespace BankApi.Domain
{
    public class Deposit
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public ICollection<ClientDeposit> ClientDeposits { get; set; }
    }
}
