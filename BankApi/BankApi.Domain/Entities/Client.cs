namespace BankApi.Domain.Entities
{
    public class Client
    {
        public Guid Id { get; set; }

        public string Surname { get; set; }

        public string Name { get; set; }

        public string? Patronymic { get; set; }

        public DateTime DateBirth { get; set; }

        public ushort SerialPassport { get; set; }

        public uint NumberPassport { get; set; }

        public string Login { get; set; }

        public string PasswordHash { get; set; }

        public string? RefreshToken { get; set; }

        public DateTime RefreshTokenExpiryTime { get; set; }
    }
}
