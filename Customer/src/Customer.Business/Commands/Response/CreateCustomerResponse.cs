namespace Customer.Business.Commands.Response;

/// <summary>Create Customer Response Model</summary>
public class CreateCustomerResponse
{
    /// <summary>Gets or sets the customer identifier.</summary>
    /// <value>The customer identifier.</value>
    public int CustomerId { get; set; }

    /// <summary>Gets or sets a value indicating whether [customer created].</summary>
    /// <value>
    ///   <c>true</c> if [customer created]; otherwise, <c>false</c>.</value>
    public bool CustomerCreated { get; set; }
}
