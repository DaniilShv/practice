using BankApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankApi.Infrastructure.DbContextConfigs
{
    public class PaymentHistoryConfig : IEntityTypeConfiguration<PaymentHistory>
    {
        public void Configure(EntityTypeBuilder<PaymentHistory> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.BankRecord)
                .WithMany()
                .HasForeignKey(x => x.BankRecordId);
        }
    }
}
