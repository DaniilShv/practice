using BankApi.Domain.Entities;
using BankApi.Domain.Enums;

namespace BankApi.Domain.DTOs
{
    public class ClientCreditCreateDto
    {
        public Guid ClientId { get; set; }

        public Guid CreditId { get; set; }

        public decimal Total { get; set; }

        public int Dist { get; set; }

        public double Percent { get; set; }

        public TypeAccrual Type { get; set; }
    }

    public class ClientCreditRemoveDto
    {
        public Guid ClientId { get; set; }

        public Guid CreditId { get; set; }
    }

    public class TransferMoneyCreditDto
    {
        public Guid BankRecordId { get; set; }

        public Guid ClientId { get; set; }

        public Guid CreditId { get; set; }

        public decimal Sum { get; set; }
    }
}
