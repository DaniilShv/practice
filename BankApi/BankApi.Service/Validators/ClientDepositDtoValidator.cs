using BankApi.Domain.DTOs;
using FluentValidation;

namespace BankApi.Service.Validators
{
    public class ClientDepositCreateDtoValidator : AbstractValidator<ClientDepositCreateDto>
    {
        public ClientDepositCreateDtoValidator()
        {
            RuleFor(x => x.DepositId).NotEmpty();
            RuleFor(x => x.ClientId).NotEmpty();
            RuleFor(x => x.Total).NotEmpty().GreaterThan(5000);
            RuleFor(x => x.Dist).NotEmpty().GreaterThan(0);
            RuleFor(x => x.Percent).NotEmpty().GreaterThan(0);
            RuleFor(x => x.Type).NotEmpty();
        }
    }

    public class TransferMoneyDepositDtoValidator : AbstractValidator<TransferMoneyDepositDto>
    {
        public TransferMoneyDepositDtoValidator()
        {
            RuleFor(x => x.ClientId).NotEmpty();
            RuleFor(x => x.DepositId).NotEmpty();
            RuleFor(x => x.BankRecordId).NotEmpty();
            RuleFor(x => x.Sum).NotEmpty().GreaterThan(0);
        }
    }
}
