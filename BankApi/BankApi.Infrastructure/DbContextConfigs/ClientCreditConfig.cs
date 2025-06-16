using BankApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankApi.Infrastructure.DbContextConfigs
{
    public class ClientCreditConfig : IEntityTypeConfiguration<ClientCredit>
    {
        public void Configure(EntityTypeBuilder<ClientCredit> builder)
        {
            builder.HasKey(x => new { x.ClientId, x.CreditId });
        }
    }
}
