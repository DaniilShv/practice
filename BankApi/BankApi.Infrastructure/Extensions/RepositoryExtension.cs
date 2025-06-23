using BankApi.Domain.Interfaces;
using BankApi.Infrastructure.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace BankApi.Infrastructure.Extensions
{
    public static class RepositoryExtension
    {
        public static void AddRepository(this IServiceCollection services)
        {
            services.Scan(scan =>
            {
                scan.FromAssemblyOf<ClientRepository>()
                .AddClasses(classes => classes.Where(x => x.Name.EndsWith("Repository")))
                .AsImplementedInterfaces()
                .WithScopedLifetime();
            });
        }
    }
}
