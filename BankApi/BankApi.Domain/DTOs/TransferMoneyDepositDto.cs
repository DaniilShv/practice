namespace BankApi.Domain.DTOs
{
    public class TransferMoneyDepositDto
    {
        public Guid BankRecordId { get; set; }

        public Guid ClientId { get; set; }

        public Guid DepositId { get; set; }

        public decimal Sum { get; set; }
    }
}
