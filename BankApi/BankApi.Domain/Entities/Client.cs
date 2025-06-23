namespace BankApi.Domain.Entities
{
    public class Client
    {
        /// <summary>
        /// ID клиента (Primary Key)
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Отчество
        /// </summary>
        public string? Patronymic { get; set; }

        /// <summary>
        /// Дата рождения
        /// </summary>
        public DateTime DateBirth { get; set; }

        /// <summary>
        /// Серия паспорта
        /// </summary>
        public ushort SerialPassport { get; set; }

        /// <summary>
        /// Номер паспорта
        /// </summary>
        public uint NumberPassport { get; set; }

        /// <summary>
        /// Логин для входа в систему банка
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Пароль для входа в систему банка
        /// </summary>
        public string PasswordHash { get; set; }

        public string? RefreshToken { get; set; }

        public DateTime RefreshTokenExpiryTime { get; set; }
    }
}
