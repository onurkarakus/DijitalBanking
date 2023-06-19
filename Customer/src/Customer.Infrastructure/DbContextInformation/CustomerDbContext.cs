using Customer.Domain.DataModels;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace Customer.Infrastructure.DbContextInformation
{
    public class CustomerDbContext : DbContext
    {
        public DbSet<CustomerInformation> CustomerInformations { get; set; }
        public DbSet<CustomerSecurity> CustomerSecurities { get; set; }

        public CustomerDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            base.OnModelCreating(mb);

            mb.Entity<CustomerInformation>()
            .HasData(
            new CustomerInformation
            {
                Id = 1,
                FirstName = "Mehmet",
                MiddleName = "Onur",
                LastName = "Yılmaz",
                BirthDate = new DateTime(1980, 1, 25),
                FavoriteFootballTeam = "Galatasaray",
                Address = "Test Adres Bilgisi",
                EmailAddress = "test@test.com",
                MobileNumber = "5555555555",
                CreatedBy = "SeedBatch",
                CreatedDate = DateTime.Now,
                UpdatedBy = "SeedBatch",
                UpdateDate = DateTime.Now
            });
        }
    }
}
