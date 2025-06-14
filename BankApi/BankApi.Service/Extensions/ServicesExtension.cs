﻿using BankApi.Service.Interfaces;
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
        }
    }
}
