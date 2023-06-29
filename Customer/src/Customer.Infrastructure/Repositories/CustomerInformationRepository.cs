using Customer.Domain.DataModels;
using Customer.Infrastructure.DbContextInformation;
using Customer.Infrastructure.Repositories.Interfaces;
using DigitalBanking.Common.Repositories;

namespace Customer.Infrastructure.Repositories;

public class CustomerInformationRepository : BaseRepository<CustomerInformation, int, CustomerDbContext>, ICustomerInformationRespository
{
    public CustomerInformationRepository(CustomerDbContext dbContext) : base(dbContext)
    {

    }
}
