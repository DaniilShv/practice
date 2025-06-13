namespace BankApi.Domain.DTOs
{
    public class BankBranchCreateDto
    {
        public Guid LocationId { get; set; }
        public string Adress { get; set; }
    }
}
