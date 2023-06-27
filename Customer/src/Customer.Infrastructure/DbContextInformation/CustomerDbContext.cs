using Customer.Domain.DataModels;
using Microsoft.EntityFrameworkCore;

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
            //Left empty on purpose
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
                AddressDescription = "Ev Adresi",
                IsFavoriteAddress = true,
                CreatedBy = "SeedBatch",
                CreatedDate = DateTime.Now,
                UpdatedBy = "SeedBatch",
                UpdatedDate = DateTime.Now
            });

            mb.Entity<CustomerSecurity>()
                .HasData(
                new CustomerSecurity
                {
                    Id = 1,
                    CustomerId = 1,
                    Password = "F+qm2jfPeT0sHU5Uf6ZWa2wy9QPCuKo+rbNjf5pKk4BlHJl5LL63ovDPXAMbYIZ58biqvAaTD6B23PDhK/K8TQ==",
                    PasswordSalt = "aW2MIhfFInZM5mrK2JOcIX7wY/tmdjCk8r0M3xWvQW0=",
                    UserName = "onuryilmaz",
                    SecurityQuestion = "En sevdiğiniz renk nedir?",
                    SecurityAnswer = "Mavi",
                    CreatedBy = "SeedBatch",
                    CreatedDate = DateTime.Now,
                    UpdatedBy = "SeedBatch",
                    UpdatedDate = DateTime.Now
                }
                );

        }
    }
}
