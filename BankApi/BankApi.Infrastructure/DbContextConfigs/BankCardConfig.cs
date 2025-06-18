using BankApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankApi.Infrastructure.DbContextConfigs
{
    internal class BankCardConfig : IEntityTypeConfiguration<BankCard>
    {
        public void Configure(EntityTypeBuilder<BankCard> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.BankRecord)
                .WithMany()
                .HasForeignKey(x => x.BankRecordId);
        }
    }
}
