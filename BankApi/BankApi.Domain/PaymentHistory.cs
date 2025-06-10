using BankApi.Domain.Enums;

namespace BankApi.Domain
{
    public class PaymentHistory
    {
        public Guid Id { get; set; }

        public BankRecord BankRecord { get; set; }

        public Guid BankRecordId { get; set; }

        public string Name { get; set; }

        public decimal Total { get; set; }

        public DateTime Date { get; set; }

        public PaymentStatus Status { get; set; }
    }
}
