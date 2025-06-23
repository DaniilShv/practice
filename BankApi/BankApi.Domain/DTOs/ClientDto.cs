using BankApi.Domain.Entities;

namespace BankApi.Domain.DTOs
{
    public class ClientCreateDto
    {
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
        /// Серия паспорта
        /// </summary>
        public ushort SerialPassport { get; set; }

        /// <summary>
        /// Номер паспорта
        /// </summary>
        public uint NumberPassport { get; set; }

        /// <summary>
        /// Логин для входа в банковскую систему
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Пароль для входы в банковскую систему
        /// </summary>
        public string Password { get; set; }
    }

    public class ClientShowDto
    {
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
    }
}
