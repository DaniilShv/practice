using BankApi.Domain.Enums;

namespace BankApi.Domain.Entities
{
    public class ClientDeposit
    {
        public Client Client { get; set; }
        public Guid ClientId { get; set; }
        public Deposit Deposit { get; set; }
        public Guid DepositId { get; set; }
        public decimal Total { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateAccrualPercent { get; set; }
        public DateTime DateFinal { get; set; }
        public double Percent { get; set; }
        public TypeAccrual Type { get; set; }
    }
}
