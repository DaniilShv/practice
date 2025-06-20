using BankApi.Service.Interfaces;
using BankApi.Service.MappingProfiles;
using Microsoft.AspNetCore.Authentication.OAuth.Claims;
using Microsoft.Extensions.DependencyInjection;

namespace BankApi.Service.Extensions
{
    public static class ServicesExtension
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(BankProfile));

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
