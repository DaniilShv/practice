using BankApi.Domain.Enums;

namespace BankApi.Domain.Entities
{
    public class PaymentHistory
    {
        /// <summary>
        /// ID платежа (Primary Key)
        /// </summary>
        public Guid Id { get; set; }

        public BankRecord BankRecord { get; set; }

        /// <summary>
        /// С какого счета сделали платеж (Foreign Key)
        /// </summary>
        public Guid BankRecordId { get; set; }

        /// <summary>
        /// Название получателя платежа
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Сумма платежа
        /// </summary>
        public decimal Total { get; set; }

        /// <summary>
        /// Дата платежа
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Статус платежа в банке
        /// </summary>
        public PaymentStatus Status { get; set; }
    }
}
