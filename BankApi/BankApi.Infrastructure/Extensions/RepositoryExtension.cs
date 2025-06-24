using BankApi.Domain.Interfaces;
using BankApi.Infrastructure.Repository;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel;
using System.Data;

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

        public static DataTable ToDataTable<T>(this IQueryable<T> data)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));

            DataTable table = new DataTable();

            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, prop.PropertyType);

            foreach (var item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }

            return table;
        }
    }
}
