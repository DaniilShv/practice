namespace BankApi.Domain.DTOs
{
    public class BankRecordDto
    {
        public Guid Id { get; set; }
        public decimal Total { get; set; }
    }

    public class BankRecordCreateDto
    {
        public Guid ClientId { get; set; }

        public Guid BankBranchId { get; set; }
    }

    public class DepositBankRecordDto
    {
        public Guid BankRecordId { get; set; }

        public decimal Total { get; set; }
    }

    public class WithdrawalBankRecordDto
    {
        public Guid BankRecordId { get; set; }

        public decimal Sum { get; set; }
    }
}
