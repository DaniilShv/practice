using BankApi.Domain.DTOs;
using FluentValidation;

namespace BankApi.Service.Validators
{
    public class BankBranchCreateDtoValidator : AbstractValidator<BankBranchCreateDto>
    {
        public BankBranchCreateDtoValidator()
        {
            RuleFor(x => x.Adress).NotEmpty();
            RuleFor(x => x.LocationId).NotEmpty();
        }
    }
}
