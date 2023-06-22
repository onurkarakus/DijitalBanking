namespace Customer.Business.Commands.Response;

/// <summary>Login Customer Response</summary>
public class LoginCustomerResponse
{
    /// <summary>Gets or sets the customer identifier.</summary>
    /// <value>The customer identifier.</value>
    public int CustomerId { get; set; }

    /// <summary>Gets or sets the token.</summary>
    /// <value>The token.</value>
    public string Token { get; set; }

    /// <summary>Gets the token expire date.</summary>
    /// <value>The token expire date.</value>
    public DateTime TokenExpireDate { get; internal set; }
}
