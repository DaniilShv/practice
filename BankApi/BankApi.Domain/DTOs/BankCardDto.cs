namespace BankApi.Domain.DTOs
{
    public class BankCardShowDto
    {
        public ulong CardNumber { get; set; }

        public DateTime Date { get; set; }

        public ushort CvvCode { get; set; }
    }

    public class BankCardPayDto
    {
        public Guid CardId { get; set; }

        public decimal Sum { get; set; }
    }
}
