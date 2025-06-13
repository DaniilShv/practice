using BankApi.Domain.DTOs;
using FluentValidation;

namespace BankApi.Service.Validators
{
    public class ClientCreateDtoValidator : AbstractValidator<ClientCreateDto>
    {
        public ClientCreateDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Surname).NotEmpty();
            RuleFor(x => x.SerialPassport).NotEmpty().Must(x => x == 4);
            RuleFor(x => x.NumberPassport).NotEmpty().Must(x => x == 6);
            RuleFor(x => x.Login).NotEmpty();
            RuleFor(x => x.Password).NotEmpty();
        }
    }
}
