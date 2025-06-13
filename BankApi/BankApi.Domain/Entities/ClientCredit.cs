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
        public Guid ClientId { get; set; }
        public Credit Credit { get; set; }
        public Guid CreditId { get; set; }
        public decimal Total { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateAccrualPercent { get; set; }
        public DateTime DateFinal { get; set; }
        public double Percent { get; set; }
        public TypeAccrual Type { get; set; }
    }
}
