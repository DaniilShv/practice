using BankApi.Domain.Enums;

namespace BankApi.Domain
{
    public class Employee
    {
        public Guid Id { get; set; }

        public BankBranch BankBranch { get; set; }

        public Guid BankBranchId { get; set; }

        public ICollection<BankRecord> BankRecords { get; set; }

        public string Surname { get; set; }

        public string Name { get; set; }

        public string? Patronymic { get; set; }

        public DateOnly DateBirth { get; set; }

        public Education Education { get; set; }

        public Gender Gender { get; set; }

        public string Position { get; set; }

        public decimal Salary { get; set; }

        public string Login { get; set; }

        public string PasswordHash { get; set; }
    }
}
