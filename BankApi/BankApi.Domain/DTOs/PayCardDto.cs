namespace BankApi.Domain.DTOs
{
    public class PayCardDto
    {
        public Guid CardId { get; set; }

        public decimal Sum { get; set; }
    }
}
