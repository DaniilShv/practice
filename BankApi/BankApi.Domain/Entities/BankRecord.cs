namespace BankApi.Domain.Entities
{
    public class BankRecord
    {
        /// <summary>
        /// ID банковского счета (Primary Key)
        /// </summary>
        public Guid Id { get; set; }

        public Client Client { get; set; }

        /// <summary>
        /// Клиент, на которого оформлен банковский счет (Foreign Key)
        /// </summary>
        public Guid ClientId { get; set; }

        public BankBranch BankBranch { get; set; }

        /// <summary>
        /// Банковское отделение, в котором оформлен счет (Foreign Key)
        /// </summary>
        public Guid BankBranchId { get; set; }

        /// <summary>
        /// Количество денег на банковском счету
        /// </summary>
        public decimal Total { get; set; }
    }
}
