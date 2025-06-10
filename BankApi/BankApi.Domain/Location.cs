namespace BankApi.Domain
{
    public class Location
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public ICollection<BankBranch> BankBranches { get; set; }
    }
}
