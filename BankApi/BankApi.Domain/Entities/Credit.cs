namespace BankApi.Domain.Entities
{
    public class Credit
    {
        public Guid Id { get; set; }
        public ICollection<ClientCredit> ClientCredits { get; set; }
        public string Name { get; set; }
    }
}
