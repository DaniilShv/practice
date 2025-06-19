using BankApi.Service.Interfaces;
using BankApi.Service.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace BankApi.Service.Extensions
{
    public static class JwtServiceExtension
    {
        public static void AddJwtService(this IServiceCollection services, IConfiguration config)
        {
            var settings = config.GetSection("Jwt").Get<JwtSettings>();

            if (settings == null)
                throw new ArgumentNullException("Create Jwt settings");

            services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = settings.ValidateIssuer,
                        ValidateAudience = settings.ValidateAudience,
                        ValidateLifetime = settings.ValidateLifetime,
                        ValidateIssuerSigningKey = settings.ValidateIssuerSigningKey,
                        ValidIssuer = settings.Issuer,
                        ValidAudience = settings.Audience,
                        IssuerSigningKey = 
                        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(settings.SecretKey))
                    };

                    options.Events = new JwtBearerEvents
                    {
                        OnMessageReceived = context =>
                        {
                            context.Token = context.Request.Cookies["tasty_cookie"];
                            return Task.CompletedTask;
                        }
                    };
                });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("User", policy =>
                {
                    policy.RequireClaim("BankUserStatus");
                });

                options.AddPolicy("UserDepositCredit", policy =>
                {
                    policy.RequireClaim("BankUserStatus", "ElderUser");
                });

                options.AddPolicy("Employee", policy =>
                {
                    policy.RequireClaim("EmployeeStatus");
                });

                options.AddPolicy("Manager", policy =>
                {
                    policy.RequireClaim("EmployeeStatus", "Manager");
                });

                options.AddPolicy("Director", policy =>
                {
                    policy.RequireClaim("EmployeeStatus", "Director");
                });

            });
        }
    }
}
