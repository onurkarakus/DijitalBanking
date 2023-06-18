using Customer.Domain.Models;

namespace Customer.Business.Queries.Response;

public class GetCustomerInformationResponse
{
    public CustomerInformationDto CustomerInformation { get; internal set; }
}
