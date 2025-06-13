using BankApi.Domain.DTOs;
using FluentValidation;

namespace BankApi.Service.Validators
{
    public class BankRecordCreateDtoValidator : AbstractValidator<BankRecordCreateDto>
    {
        public BankRecordCreateDtoValidator()
        {
            RuleFor(x => x.BankBranchId).NotEmpty();
            RuleFor(x => x.ClientId).NotEmpty();
        }
    }

    public class DepositBankRecordDtoValidator : AbstractValidator<DepositBankRecordDto>
    {
        public DepositBankRecordDtoValidator()
        {
            RuleFor(x => x.BankRecordId).NotEmpty();
            RuleFor(x => x.Total).NotEmpty().GreaterThan(0);
        }
    }

    public class WithdrawalBankRecordDtoValidator : AbstractValidator<WithdrawalBankRecordDto>
    {
        public WithdrawalBankRecordDtoValidator()
        {
            RuleFor(x => x.BankRecordId).NotEmpty();
            RuleFor(x => x.Sum).NotEmpty().GreaterThan(0);
        }
    }
}
