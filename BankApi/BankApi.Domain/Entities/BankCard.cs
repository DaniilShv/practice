namespace BankApi.Domain.Entities
{
    public class BankCard
    {
        public Guid Id { get; set; }

        public BankRecord BankRecord { get; set; }

        public Guid BankRecordId { get; set; }

        public ulong CardNumber { get; set; }

        public DateTime Date { get; set; }

        public ushort CvvCode { get; set; }
    }
}
