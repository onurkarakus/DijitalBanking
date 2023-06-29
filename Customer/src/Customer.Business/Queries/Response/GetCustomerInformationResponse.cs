using Customer.Domain.Models.ViewModels;

namespace Customer.Business.Queries.Response;

/// <summary>Get Customer Information Response</summary>
public class GetCustomerInformationResponse
{
    /// <summary>Gets the customer information.</summary>
    /// <value>The customer information.</value>
    public CustomerInformationViewModel CustomerInformation { get; internal set; }
}
