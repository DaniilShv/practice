

using BankApi.Domain.DTOs;
using FluentValidation;

namespace BankApi.Service.Validators
{
    public class ClientCreditCreateDtoValidator : AbstractValidator<ClientCreditCreateDto>
    {
        public ClientCreditCreateDtoValidator()
        {
            RuleFor(x => x.ClientId).NotEmpty();
            RuleFor(x => x.CreditId).NotEmpty();
            RuleFor(x => x.Total).NotEmpty().GreaterThan(5000);
            RuleFor(x => x.Dist).NotEmpty().GreaterThan(0);
            RuleFor(x => x.Percent).NotEmpty().GreaterThan(0);
            RuleFor(x => x.Type).NotEmpty();
        }
    }

    public class ClientCreditRemoveDtoValidator : AbstractValidator<ClientCreditRemoveDto>
    {
        public ClientCreditRemoveDtoValidator()
        {
            RuleFor(x => x.ClientId).NotEmpty();
            RuleFor(x => x.CreditId).NotEmpty();
        }
    }
}
