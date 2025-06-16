using BankApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankApi.Infrastructure.DbContextConfigs
{
    public class CreditConfig : IEntityTypeConfiguration<Credit>
    {
        public void Configure(EntityTypeBuilder<Credit> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasMany(x => x.ClientCredits)
                .WithOne(x => x.Credit)
                .HasForeignKey(x => x.CreditId);
        }
    }
}
