using BankApi.Domain.Entities;
using BankApi.Domain.Enums;

namespace BankApi.Domain.DTOs
{
    public class ClientDepositCreateDto
    {
        /// <summary>
        /// ID клиента оформляющего вклад в банке
        /// </summary>
        public Guid ClientId { get; set; }

        /// <summary>
        /// ID вклада
        /// </summary>
        public Guid DepositId { get; set; }
        
        /// <summary>
        /// Сумма вклада
        /// </summary>
        public decimal Total { get; set; }

        /// <summary>
        /// На сколько берут вклад
        /// </summary>
        public int Dist { get; set; }

        /// <summary>
        /// Процент по вкладу
        /// </summary>
        public double Percent { get; set; }

        /// <summary>
        /// Тип вклада
        /// </summary>
        public TypeAccrual Type { get; set; }
    }

    public class TransferMoneyDepositDto
    {
        /// <summary>
        /// ID банковского счета клиента
        /// </summary>
        public Guid BankRecordId { get; set; }

        /// <summary>
        /// ID клиента
        /// </summary>
        public Guid ClientId { get; set; }

        /// <summary>
        /// ID вклада
        /// </summary>
        public Guid DepositId { get; set; }

        /// <summary>
        /// Сумма денег
        /// </summary>
        public decimal Sum { get; set; }
    }
}
