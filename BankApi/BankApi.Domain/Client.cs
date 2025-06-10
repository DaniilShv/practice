namespace BankApi.Domain
{
    public class Client
    {
        public Guid Id { get; set; }

        public ICollection<BankRecord> BankRecords { get; set; }

        public ICollection<ClientDeposit> ClientDeposits { get; set; }

        public ICollection<ClientCredit> ClientCredits { get; set; }

        public string Surname { get; set; }

        public string Name { get; set; }

        public string? Patronymic { get; set; }

        public ushort SerialPassport { get; set; }

        public uint NumberPassport { get; set; }
    }
}
