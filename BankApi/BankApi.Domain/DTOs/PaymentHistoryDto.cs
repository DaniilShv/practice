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
        public string Name { get; set; }

        public decimal Total { get; set; }

        public DateTime Date { get; set; }

        public PaymentStatus Status { get; set; }
    }
}
