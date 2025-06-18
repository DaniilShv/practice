namespace BankApi.Domain.Entities
{
    public class BankBranch
    {
        public Guid Id { get; set; }

        public Location Location { get; set; }

        public Guid LocationId { get; set; }

        public string Adress { get; set; }
    }
}
