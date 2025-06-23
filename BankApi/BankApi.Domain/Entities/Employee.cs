using BankApi.Domain.Enums;

namespace BankApi.Domain.Entities
{
    public class Employee
    {
        /// <summary>
        /// ID сотрудника (Primary Key)
        /// </summary>
        public Guid Id { get; set; }

        public BankBranch BankBranch { get; set; }

        /// <summary>
        /// Банковское отделение, в котором работает сотрудник (Foreign Key)
        /// </summary>
        public Guid BankBranchId { get; set; }

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
        public DateOnly DateBirth { get; set; }

        /// <summary>
        /// Тип образования
        /// </summary>
        public Education Education { get; set; }

        /// <summary>
        /// Пол
        /// </summary>
        public Gender Gender { get; set; }

        /// <summary>
        /// Должность сотрудника в банке
        /// </summary>
        public string Position { get; set; }

        /// <summary>
        /// Зарплата сотрудника
        /// </summary>
        public decimal Salary { get; set; }

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
