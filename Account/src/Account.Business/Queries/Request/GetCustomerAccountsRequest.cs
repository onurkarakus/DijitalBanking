using Account.Business.Queries.Response;
using MediatR;

namespace Account.Business.Queries.Request;

public class GetCustomerAccountsRequest: IRequest<GetCustomerAccountsResponse>
{
    public int CustomerId { get; set; }
}
