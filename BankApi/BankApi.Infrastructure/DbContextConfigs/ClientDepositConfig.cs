using BankApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankApi.Infrastructure.DbContextConfigs
{
    public class ClientDepositConfig : IEntityTypeConfiguration<ClientDeposit>
    {
        public void Configure(EntityTypeBuilder<ClientDeposit> builder)
        {
            builder.HasKey(x => new { x.ClientId, x.DepositId });

            builder.HasOne(x => x.Client)
                .WithMany()
                .HasForeignKey(x => x.ClientId);

            builder.HasOne(x => x.Deposit)
                .WithMany()
                .HasForeignKey(x => x.DepositId);
        }
    }
}
