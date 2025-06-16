using BankApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankApi.Infrastructure.DbContextConfigs
{
    public class BankRecordConfig : IEntityTypeConfiguration<BankRecord>
    {
        public void Configure(EntityTypeBuilder<BankRecord> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasMany(x => x.BankCards)
                .WithOne(x => x.BankRecord)
                .HasForeignKey(x => x.BankRecordId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.PaymentHistories)
                .WithOne(x => x.BankRecord)
                .HasForeignKey(x => x.BankRecordId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
