using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace BankApi.Infrastructure.Extensions
{
    public static class DbContextExtension
    {
        public static void AddDatabase(this IServiceCollection service, IConfiguration config)
        {
            service.AddDbContext<BankDbContext>((provider, options) =>
            {
                options.UseNpgsql(config.GetConnectionString("PostgresDb"),
                    o => o.EnableRetryOnFailure(3))
                    .UseLoggerFactory(provider.GetService<ILoggerFactory>());
            });
        }
    }
}
