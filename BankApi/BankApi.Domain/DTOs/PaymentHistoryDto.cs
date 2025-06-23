using BankApi.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApi.Domain.DTOs
{
    public class PaymentHistoryShowDto
    {
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
