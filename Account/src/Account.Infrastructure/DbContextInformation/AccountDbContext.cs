using Account.Domain.DataModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Infrastructure.DbContextInformation;

public class AccountDbContext : DbContext
{
    public DbSet<AccountType> AccountTypes { get; set; }
    public DbSet<AccountCurrency> AccountCurrencies { get; set; }
    public DbSet<AccountInformation> AccountInformations { get; set; }

    public AccountDbContext(DbContextOptions options) : base(options)
    {

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //Left empty on purpose
    }

    protected override void OnModelCreating(ModelBuilder mb)
    {
        base.OnModelCreating(mb);

        mb.Entity<AccountType>()
            .HasData(
            new AccountType
            {
                Id = 1,
                Name = "Vadeli Hesap",
                Description = "Vadeli Hesap",
                CreatedBy = "SeedBatch",
                CreatedDate = DateTime.Now,
                UpdatedBy = "SeedBatch",
                UpdatedDate = DateTime.Now
            },
            new AccountType
            {
                Id = 2,
                Name = "Vadesiz Hesap",
                Description = "Vadesiz Hesap",
                CreatedBy = "SeedBatch",
                CreatedDate = DateTime.Now,
                UpdatedBy = "SeedBatch",
                UpdatedDate = DateTime.Now
            });

        mb.Entity<AccountCurrency>()
            .HasData(
            new AccountCurrency
            {
                Id = 1,
                Name = "TRY",
                Description = "Türk Lirası",
                CreatedBy = "SeedBatch",
                CreatedDate = DateTime.Now,
                UpdatedBy = "SeedBatch",
                UpdatedDate = DateTime.Now
            },
            new AccountCurrency
            {
                Id = 2,
                Name = "USD",
                Description = "Amerikan Doları",                
                CreatedBy = "SeedBatch",
                CreatedDate = DateTime.Now,
                UpdatedBy = "SeedBatch",
                UpdatedDate = DateTime.Now
            },
            new AccountCurrency
            {
                Id = 3,
                Name = "EUR",
                Description = "Euro",                
                CreatedBy = "SeedBatch",
                CreatedDate = DateTime.Now,
                UpdatedBy = "SeedBatch",
                UpdatedDate = DateTime.Now
            });

        mb.Entity<AccountInformation>()
            .HasData(
            new AccountInformation
            {
                Id = 1,
                BranchCode = 1234,
                AccountNumber = "456",
                Suffix = "02",
                AccountTypeId = 2,
                AccountCurrencyId = 1,
                Balance = 1000,
                CustomerId = 1,
                AccountActive = true,
                CreatedBy = "SeedBatch",
                CreatedDate = DateTime.Now,
                UpdatedBy = "SeedBatch",
                UpdatedDate = DateTime.Now
            },
            new AccountInformation
            {
                Id = 2,
                BranchCode = 1234,
                AccountNumber = "1234",
                Suffix = "01",
                AccountTypeId = 1,
                AccountCurrencyId = 1,
                Balance = 1000,
                CustomerId = 1,
                AccountActive = true,
                CreatedBy = "SeedBatch",
                CreatedDate = DateTime.Now,
                UpdatedBy = "SeedBatch",
                UpdatedDate = DateTime.Now
            });
    }
}
