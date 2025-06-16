using BankApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankApi.Infrastructure.DbContextConfigs
{
    public class ClientDepositeConfig : IEntityTypeConfiguration<ClientDeposit>
    {
        public void Configure(EntityTypeBuilder<ClientDeposit> builder)
        {
            builder.HasKey(x => new { x.ClientId, x.DepositId });
        }
    }
}
