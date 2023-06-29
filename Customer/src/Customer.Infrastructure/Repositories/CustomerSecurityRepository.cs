using Customer.Domain.DataModels;
using Customer.Infrastructure.DbContextInformation;
using Customer.Infrastructure.Repositories.Interfaces;
using DigitalBanking.Common.Repositories;

namespace Customer.Infrastructure.Repositories;

public class CustomerSecurityRepository : BaseRepository<CustomerSecurity, int, CustomerDbContext>, ICustomerSecurityRespository
{
    public CustomerSecurityRepository(CustomerDbContext dbContext) : base(dbContext)
    {
        
    }
}
