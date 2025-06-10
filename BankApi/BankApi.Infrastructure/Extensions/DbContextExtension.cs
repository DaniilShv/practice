using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BankApi.Infrastructure.Extensions
{
    public static class DbContextExtension
    {
        public static void AddDatabase(this IServiceCollection service, IConfiguration config)
        {
            service.AddDbContext<BankDbContext>(options =>
            {
                options.UseNpgsql(config.GetConnectionString("PostgresDb"));
            });
        }
    }
}
