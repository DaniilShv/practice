namespace BankApi.Domain.DTOs
{
    public class BankCardDto
    {
        public ulong CardNumber { get; set; }

        public DateTime Date { get; set; }

        public ushort CvvCode { get; set; }
    }
}
