using BankApi.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApi.Domain.Entities
{
    public class ClientCredit
    {
        public Client Client { get; set; }

        /// <summary>
        /// ID клиента (Primary Key, Foreign Key)
        /// </summary>
        public Guid ClientId { get; set; }

        public Credit Credit { get; set; }

        /// <summary>
        /// ID Кредита (Primary Key, Foreign Key)
        /// </summary>
        public Guid CreditId { get; set; }

        /// <summary>
        /// Сумма кредита
        /// </summary>
        public decimal Total { get; set; }

        /// <summary>
        /// Дата взятия кредита в банке
        /// </summary>
        public DateTime DateStart { get; set; }

        /// <summary>
        /// Дата начисления процентов в банке
        /// </summary>
        public DateTime DateAccrualPercent { get; set; }

        /// <summary>
        /// Дата выплаты кредита в банк
        /// </summary>
        public DateTime DateFinal { get; set; }

        /// <summary>
        /// Процент по кредиту
        /// </summary>
        public double Percent { get; set; }

        /// <summary>
        /// Тип кредита
        /// </summary>
        public TypeAccrual Type { get; set; }
    }
}
