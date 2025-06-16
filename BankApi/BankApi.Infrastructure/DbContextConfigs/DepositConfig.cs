using BankApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankApi.Infrastructure.DbContextConfigs
{
    public class DepositConfig : IEntityTypeConfiguration<Deposit>
    {
        public void Configure(EntityTypeBuilder<Deposit> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasMany(x => x.ClientDeposits)
                .WithOne(x => x.Deposit)
                .HasForeignKey(x => x.DepositId);
        }
    }
}
