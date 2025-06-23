using BankApi.Domain.Entities;
using BankApi.Domain.Enums;

namespace BankApi.Domain.DTOs
{
    public class ClientCreditCreateDto
    {
        /// <summary>
        /// ID клиента, оформляющего кредит в банке
        /// </summary>
        public Guid ClientId { get; set; }

        /// <summary>
        /// ID кредита, который оформляет клиент
        /// </summary>
        public Guid CreditId { get; set; }

        /// <summary>
        /// Сумма кредита
        /// </summary>
        public decimal Total { get; set; }

        /// <summary>
        /// На сколько берут кредит
        /// </summary>
        public int Dist { get; set; }

        /// <summary>
        /// Процент по кредиту
        /// </summary>
        public double Percent { get; set; }

        /// <summary>
        /// Тип кредиты
        /// </summary>
        public TypeAccrual Type { get; set; }
    }

    public class ClientCreditRemoveDto
    {
        /// <summary>
        /// ID клиента
        /// </summary>
        public Guid ClientId { get; set; }

        /// <summary>
        /// ID кредита
        /// </summary>
        public Guid CreditId { get; set; }
    }

    public class TransferMoneyCreditDto
    {
        /// <summary>
        /// Банковский счет, с которого оплачивают
        /// </summary>
        public Guid BankRecordId { get; set; }

        /// <summary>
        /// ID клиента
        /// </summary>
        public Guid ClientId { get; set; }

        /// <summary>
        /// ID кредита
        /// </summary>
        public Guid CreditId { get; set; }

        /// <summary>
        /// Сумма денег
        /// </summary>
        public decimal Sum { get; set; }
    }
}
