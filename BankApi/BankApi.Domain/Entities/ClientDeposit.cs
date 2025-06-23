using BankApi.Domain.Enums;

namespace BankApi.Domain.Entities
{
    public class ClientDeposit
    {
        public Client Client { get; set; }

        /// <summary>
        /// ID клиента (Primary Key, Foreign Key)
        /// </summary>
        public Guid ClientId { get; set; }

        public Deposit Deposit { get; set; }

        /// <summary>
        /// ID вклада (Primary Key, Foreign Key)
        /// </summary>
        public Guid DepositId { get; set; }

        /// <summary>
        /// Сумма вклада
        /// </summary>
        public decimal Total { get; set; }

        /// <summary>
        /// Дата взятия вклада в банке
        /// </summary>
        public DateTime DateStart { get; set; }

        /// <summary>
        /// Дата начисления процентов по вкалу в банке
        /// </summary>
        public DateTime DateAccrualPercent { get; set; }

        /// <summary>
        /// Дата выплаты вклада в банке
        /// </summary>
        public DateTime DateFinal { get; set; }

        /// <summary>
        /// Процент по вкладу
        /// </summary>
        public double Percent { get; set; }

        /// <summary>
        /// Тип вклада
        /// </summary>
        public TypeAccrual Type { get; set; }
    }
}
