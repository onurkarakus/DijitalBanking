using Customer.Domain.DataModels;
using Customer.Domain.Interfaces.Respoistories.Base;

namespace Customer.Domain.Interfaces.Respoistories;

public interface ICustomerInformationRespository : IBaseRepository<CustomerInformation, int>
{

}
