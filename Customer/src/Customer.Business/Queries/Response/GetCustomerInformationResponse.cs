using Customer.Domain.Models;

namespace Customer.Business.Queries.Response;

/// <summary>Get Customer Information Response</summary>
public class GetCustomerInformationResponse
{
    /// <summary>Gets the customer information.</summary>
    /// <value>The customer information.</value>
    public CustomerInformationDto CustomerInformation { get; internal set; }
}
