using Microsoft.AspNetCore.Mvc;

namespace BankApi.Extensions
{
    public static class ControllerExtensions
    {
        public static void AddApiVersion(this IServiceCollection services)
        {
            services.AddApiVersioning(config =>
            {
                config.DefaultApiVersion = new ApiVersion(1, 0);
                config.AssumeDefaultVersionWhenUnspecified = true;
            });
        }
    }
}
