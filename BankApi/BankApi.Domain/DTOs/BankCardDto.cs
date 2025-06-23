namespace BankApi.Domain.DTOs
{
    public class BankCardShowDto
    {
        /// <summary>
        /// Номер банковской карты
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

    public class BankCardPayDto
    {
        /// <summary>
        /// ID банковской карты
        /// </summary>
        public Guid CardId { get; set; }

        /// <summary>
        /// Сумма платежа
        /// </summary>
        public decimal Sum { get; set; }

        /// <summary>
        /// Имя получателя платежа
        /// </summary>
        public string NameSeller { get; set; }
    }
}
