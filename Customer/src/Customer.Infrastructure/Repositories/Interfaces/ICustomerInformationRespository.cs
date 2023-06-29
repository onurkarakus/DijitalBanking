using Customer.Domain.DataModels;
using Customer.Infrastructure.DbContextInformation;
using DigitalBanking.Common.Interfaces.Respoistory;

namespace Customer.Infrastructure.Repositories.Interfaces;

public interface ICustomerInformationRespository : IBaseRepository<CustomerInformation, int, CustomerDbContext>
{

}
