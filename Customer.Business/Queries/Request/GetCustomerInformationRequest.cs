using Customer.Business.Queries.Response;
using MediatR;

namespace Customer.Business.Queries.Request;

public class GetCustomerInformationRequest: IRequest<GetCustomerInformationResponse>
{
    public int CustomerId { get; set; }
}
