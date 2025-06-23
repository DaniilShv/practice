namespace BankApi.Domain.DTOs
{
    public class BankRecordDto
    {
        /// <summary>
        /// ID Банковского счета
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Деньги на банковском счету
        /// </summary>
        public decimal Total { get; set; }
    }

    public class BankRecordCreateDto
    {
        /// <summary>
        /// ID клиента, который оформляет банковский счет
        /// </summary>
        public Guid ClientId { get; set; }

        /// <summary>
        /// Банковское отделение, в котором оформлен банковский счет
        /// </summary>
        public Guid BankBranchId { get; set; }
    }

    public class DepositBankRecordDto
    {
        /// <summary>
        /// ID банковского счета клиента
        /// </summary>
        public Guid BankRecordId { get; set; }

        /// <summary>
        /// Сумма денег
        /// </summary>
        public decimal Total { get; set; }
    }

    public class WithdrawalBankRecordDto
    {
        /// <summary>
        /// ID банковского счета клиента
        /// </summary>
        public Guid BankRecordId { get; set; }

        /// <summary>
        /// Сумма денег
        /// </summary>
        public decimal Sum { get; set; }
    }
}
