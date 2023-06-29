using Customer.Domain.DataModels;
using Customer.Infrastructure.DbContextInformation;
using DigitalBanking.Common.Interfaces.Respoistory;

namespace Customer.Infrastructure.Repositories.Interfaces;

public interface ICustomerSecurityRespository : IBaseRepository<CustomerSecurity, int, CustomerDbContext>
{

}
