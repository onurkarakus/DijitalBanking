using Customer.Business.Queries.Response;
using MediatR;

namespace Customer.Business.Queries.Request;

/// <summary>Get Customer Information Request</summary>
public class GetCustomerInformationRequest: IRequest<GetCustomerInformationResponse>
{
    /// <summary>Gets or sets the customer identifier.</summary>
    /// <value>The customer identifier.</value>
    public int CustomerId { get; set; }
}
