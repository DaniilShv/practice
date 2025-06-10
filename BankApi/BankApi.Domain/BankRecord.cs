namespace BankApi.Domain
{
    public class BankRecord
    {
        public Guid Id { get; set; }

        public ICollection<BankCard> BankCards { get; set; }

        public ICollection<PaymentHistory> PaymentHistories { get; set; }

        public Client Client { get; set; }

        public Guid ClientId { get; set; }

        public BankBranch BankBranch { get; set; }

        public Guid BankBranchId { get; set; }

        public decimal Total { get; set; }
    }
}
