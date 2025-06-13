using BankApi.Domain.Entities;

namespace BankApi.Domain.DTOs
{
    public class ClientCreateDto
    {
        public string Surname { get; set; }

        public string Name { get; set; }

        public string? Patronymic { get; set; }

        public ushort SerialPassport { get; set; }

        public uint NumberPassport { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }
    }

    public class ClientShowDto
    {
        public string Surname { get; set; }

        public string Name { get; set; }

        public string? Patronymic { get; set; }

        public DateTime DateBirth { get; set; }

        public ushort SerialPassport { get; set; }

        public uint NumberPassport { get; set; }
    }
}
