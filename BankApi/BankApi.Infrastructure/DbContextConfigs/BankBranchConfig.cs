using BankApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankApi.Infrastructure.DbContextConfigs
{
    public class BankBranchConfig : IEntityTypeConfiguration<BankBranch>
    {
        public void Configure(EntityTypeBuilder<BankBranch> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasMany(x => x.Employees)
                .WithOne(x => x.BankBranch)
                .HasForeignKey(x => x.BankBranchId);

            builder.HasMany(x => x.BankRecords)
                .WithOne(x => x.BankBranch)
                .HasForeignKey(x => x.BankBranchId);
        }
    }
}
