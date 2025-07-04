﻿using BankApi.Domain.Entities;
using BankApi.Infrastructure.DbContextConfigs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

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
            modelBuilder.ApplyConfiguration(new BankCardConfig());
            modelBuilder.ApplyConfiguration(new BankRecordConfig());
            modelBuilder.ApplyConfiguration(new EmployeeConfig());
            modelBuilder.ApplyConfiguration(new PaymentHistoryConfig());
            modelBuilder.ApplyConfiguration(new ClientCreditConfig());
            modelBuilder.ApplyConfiguration(new ClientDepositConfig());
            base.OnModelCreating(modelBuilder);
        }
    }
}
