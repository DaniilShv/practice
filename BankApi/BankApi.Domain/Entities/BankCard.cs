namespace BankApi.Domain.Entities
{
    public class BankCard
    {
        /// <summary>
        /// ID банковской карты (Primary Key)
        /// </summary>
        public Guid Id { get; set; }

        public BankRecord BankRecord { get; set; }

        /// <summary>
        /// Банковский счет, на который ссылается карта (Foreign Key)
        /// </summary>
        public Guid BankRecordId { get; set; }

        /// <summary>
        /// Номер карты
        /// </summary>
        public ulong CardNumber { get; set; }

        /// <summary>
        /// Дата оформления банковской карты
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// CVV-code банковской карты
        /// </summary>
        public ushort CvvCode { get; set; }
    }
}
