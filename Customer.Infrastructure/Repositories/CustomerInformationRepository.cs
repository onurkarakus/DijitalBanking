using Customer.Domain.DataModels;
using Customer.Domain.Interfaces.Respoistories;
using Customer.Infrastructure.DbContextInformation;
using Customer.Infrastructure.Repositories.Base;

namespace Customer.Infrastructure.Repositories;

public class CustomerInformationRepository : BaseRepository<CustomerInformation, int>, ICustomerInformationRespository
{
    private readonly CustomerDbContext carRentalDbContext;

    public CustomerInformationRepository(CustomerDbContext dbContext) : base(dbContext)
    {
        this.carRentalDbContext = dbContext;
    }
}
