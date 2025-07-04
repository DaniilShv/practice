﻿using BankApi.Domain.DTOs;
using FluentValidation;

namespace BankApi.Service.Validators
{
    public class BankCardPayDtoValidator : AbstractValidator<BankCardPayDto>
    {
        public BankCardPayDtoValidator()
        {
            RuleFor(x => x.CardId).NotEmpty();
            RuleFor(x => x.Sum).NotEmpty().GreaterThan(0);
            RuleFor(x => x.NameSeller).NotEmpty().Must(x => x.Length > 0);
        }
    }
}
