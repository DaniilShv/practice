using BankApi.Service.Interfaces;
using BankApi.Service.MappingProfiles;
using Microsoft.Extensions.DependencyInjection;

namespace BankApi.Service.Extensions
{
    public static class ServicesExtension
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<ILocationService, LocationService>();
            services.AddScoped<IBankCardService, BankCardService>();
            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<IBankBranchService, BankBranchService>();
            services.AddScoped<IClientDepositsService, ClientDepositsService>();
            services.AddScoped<IBankRecordService, BankRecordService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IClientCreditService, ClientCreditService>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<ITokenService, JwtTokenService>();
            services.AddAutoMapper(typeof(BankProfile));
        }
    }
}
