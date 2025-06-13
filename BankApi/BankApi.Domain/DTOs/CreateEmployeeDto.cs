using BankApi.Domain.Enums;

namespace BankApi.Domain.DTOs
{
    public class CreateEmployeeDto
    {
        public Guid BankBranchId { get; set; }

        public string Surname { get; set; }

        public string Name { get; set; }

        public string? Patronymic { get; set; }

        public DateOnly DateBirth { get; set; }

        public Education Education { get; set; }

        public Gender Gender { get; set; }

        public string Position { get; set; }

        public decimal Salary { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }
    }
}
