using BankApi.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.DependencyInjection;

namespace BankApi.Infrastructure
{
    public class BankDbContext(DbContextOptions<BankDbContext> options) : DbContext(options)
    {
        public DbSet<BankBranch> BankBranches { get; set; }
        public DbSet<BankCard> BankCards { get; set; }
        public DbSet<BankRecord> BankRecords { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<ClientCredit> ClientCredits { get; set; }
        public DbSet<ClientDeposit> ClientDeposits { get; set; }
        public DbSet<Credit> Credits { get; set; }
        public DbSet<Deposit> Deposits { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<PaymentHistory> PaymentHistories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BankBranchConfig());
            modelBuilder.ApplyConfiguration(new LocationConfig());
            modelBuilder.ApplyConfiguration(new BankRecordConfig());
            modelBuilder.ApplyConfiguration(new ClientConfig());
            modelBuilder.ApplyConfiguration(new DepositConfig());
            modelBuilder.ApplyConfiguration(new CreditConfig());
            modelBuilder.ApplyConfiguration(new ClientCreditConfig());
            modelBuilder.ApplyConfiguration(new ClientDepositeConfig());
            base.OnModelCreating(modelBuilder);
        }
    }

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

    public class LocationConfig : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasMany(x => x.BankBranches)
                .WithOne(x => x.Location)
                .HasForeignKey(x => x.LocationId);
        }
    }

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

    public class ClientConfig : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasMany(x => x.BankRecords)
                .WithOne(x => x.Client)
                .HasForeignKey(x => x.ClientId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.ClientCredits)
                .WithOne(x => x.Client)
                .HasForeignKey(x => x.ClientId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.ClientDeposits)
                .WithOne(x => x.Client)
                .HasForeignKey(x => x.ClientId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

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

    public class ClientCreditConfig : IEntityTypeConfiguration<ClientCredit>
    {
        public void Configure(EntityTypeBuilder<ClientCredit> builder)
        {
            builder.HasKey(x => new { x.ClientId, x.CreditId });
        }
    }

    public class ClientDepositeConfig : IEntityTypeConfiguration<ClientDeposit>
    {
        public void Configure(EntityTypeBuilder<ClientDeposit> builder)
        {
            builder.HasKey(x => new { x.ClientId, x.DepositId });
        }
    }
}
