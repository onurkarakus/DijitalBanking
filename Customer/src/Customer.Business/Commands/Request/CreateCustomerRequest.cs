using Customer.Business.Commands.Response;
using MediatR;

namespace Customer.Business.Commands.Request;

public class CreateCustomerRequest : IRequest<CreateCustomerResponse>
{
    public string FirstName { get; set; }

    public string MiddleName { get; set; }

    public string LastName { get; set; }

    public string EmailAddress { get; set; }

    public string MobileNumber { get; set; }

    public string Address { get; set; }   

    public string AddressDescription { get; set; }

    public bool IsFavoriteAddress { get; set; }

    public string UserName { get; set; }

    public string Password { get; set; }

    public string SecurityQuestion { get; set; }

    public string SecurityAnswer { get; set; }
}
