using BankApi.Domain.Interfaces;
using BankApi.Service.Interfaces;
using BankApi.Service.MappingProfiles;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel;
using System.Data;

namespace BankApi.Service.Extensions
{
    public static class ServicesExtension
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(BankCardProfile), typeof(BankBranchProfile),
                typeof(BankClientProfile), typeof(BankEmployeeProfile), typeof(BankRecordProfile),
                typeof(ClientCreditProfile), typeof(ClientDepositProfile));

            services.Scan(scan =>
            {
                scan.FromAssemblyOf<IClientService>()
                .AddClasses(classes => classes.Where(x => x.Name.EndsWith("Service")))
                .AsImplementedInterfaces()
                .WithScopedLifetime();
            });
        }
    }
}
