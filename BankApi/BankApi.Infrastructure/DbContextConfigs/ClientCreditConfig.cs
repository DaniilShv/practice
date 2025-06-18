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

            builder.HasOne(x => x.Client)
                .WithMany()
                .HasForeignKey(x => x.ClientId);

            builder.HasOne(x => x.Credit)
                .WithMany()
                .HasForeignKey(x => x.CreditId);
        }
    }
}
