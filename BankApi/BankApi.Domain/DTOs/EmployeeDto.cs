using BankApi.Domain.Entities;
using BankApi.Domain.Enums;

namespace BankApi.Domain.DTOs
{
    public class EmployeeShowDto
    {
        public string Surname { get; set; }

        public string Name { get; set; }

        public string? Patronymic { get; set; }

        public DateOnly DateBirth { get; set; }

        public string Position { get; set; }
    }
}
