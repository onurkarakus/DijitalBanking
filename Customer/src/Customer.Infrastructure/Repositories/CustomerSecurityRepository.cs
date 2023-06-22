using Customer.Domain.DataModels;
using Customer.Domain.Interfaces.Respoistories;
using Customer.Infrastructure.DbContextInformation;
using Customer.Infrastructure.Repositories.Base;

namespace Customer.Infrastructure.Repositories;

public class CustomerSecurityRepository : BaseRepository<CustomerSecurity, int>, ICustomerSecurityRespository
{
    private readonly CustomerDbContext carRentalDbContext;

    public CustomerSecurityRepository(CustomerDbContext dbContext) : base(dbContext)
    {
        this.carRentalDbContext = dbContext;
    }
}
