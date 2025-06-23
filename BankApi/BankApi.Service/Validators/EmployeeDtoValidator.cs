using BankApi.Domain.DTOs;
using FluentValidation;

namespace BankApi.Service.Validators
{
    public class EmployeeCreateDtoValidator : AbstractValidator<CreateEmployeeDto>
    {
        public EmployeeCreateDtoValidator()
        {
            RuleFor(x => x.Surname).NotEmpty();
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.BankBranchId).NotEmpty();
            RuleFor(x => x.DateBirth).NotEmpty().Must(x => GetAgeClient(x) >= 14);
            RuleFor(x => x.Position).NotEmpty();
            RuleFor(x => x.Salary).NotEmpty();
            RuleFor(x => x.Login).NotEmpty();
            RuleFor(x => x.Password).NotEmpty();
        }

        int GetAgeClient(DateOnly dt)
        {
            DateTime current = DateTime.UtcNow;

            int age = current.Year - dt.Year;
            if (current.Month - dt.Month < 0)
                age--;
            else
                if (current.Day - dt.Day < 0)
                age--;

            return age;
        }
    }
}
