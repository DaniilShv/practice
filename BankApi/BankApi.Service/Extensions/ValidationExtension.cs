using BankApi.Domain.DTOs;
using BankApi.Service.Validators;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Extensions;

namespace BankApi.Service.Extensions
{
    public static class ValidationExtension
    {
        public static void AddValidation(this IServiceCollection services)
        {
            services.AddScoped<IValidator<BankCardPayDto>,BankCardPayDtoValidator>();
            services.AddScoped<IValidator<BankBranchCreateDto>,BankBranchCreateDtoValidator>();
            services.AddScoped<IValidator<BankBranchCreateDto>,BankBranchCreateDtoValidator>();
            services.AddScoped<IValidator<BankRecordCreateDto>, BankRecordCreateDtoValidator>();
            services.AddScoped<IValidator<DepositBankRecordDto>, DepositBankRecordDtoValidator>();
            services.AddScoped<IValidator<WithdrawalBankRecordDto>, WithdrawalBankRecordDtoValidator>();
            services.AddScoped<IValidator<ClientCreditCreateDto>, ClientCreditCreateDtoValidator>();
            services.AddScoped<IValidator<ClientCreditRemoveDto>, ClientCreditRemoveDtoValidator>();
            services.AddScoped<IValidator<ClientDepositCreateDto>, ClientDepositCreateDtoValidator>();
            services.AddScoped<IValidator<TransferMoneyDepositDto>, TransferMoneyDepositDtoValidator>();
            services.AddScoped<IValidator<ClientCreateDto>, ClientCreateDtoValidator>();
            services.AddScoped<IValidator<CreateEmployeeDto>, EmployeeCreateDtoValidator>();
            services.AddScoped<IValidator<LoginDto>, LoginDtoValidator>();
            services.AddScoped<IValidator<TokenDto>, TokenDtoValidator>();
            services.AddFluentValidationAutoValidation();
        }
    }
}
