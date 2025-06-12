using BankApi.Infrastructure.Interfaces;
using BankApi.Infrastructure.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace BankApi.Infrastructure.Extensions
{
    public static class RepositoryExtension
    {
        public static void AddRepository(this IServiceCollection service)
        {
            service.AddScoped<ILocationRepository, LocationRepository>();
            service.AddScoped<IBankCardRepository, BankCardRepository>();
            service.AddScoped<IClientRepository, ClientRepository>();
            service.AddScoped<IBankBranchRepository, BankBranchRepository>();
            service.AddScoped<IClientDepositsRepository, ClientDepositsRepository>();
            service.AddScoped<IBankRecordRepository, BankRecordRepository>();
        }
    }
}
