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

            builder.HasOne(x => x.BankBranch)
                .WithMany()
                .HasForeignKey(x => x.BankBranchId);

            builder.HasOne(x => x.Client)
                .WithMany()
                .HasForeignKey(x => x.ClientId);
        }
    }
}
