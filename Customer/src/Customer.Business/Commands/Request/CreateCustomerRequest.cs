using Customer.Business.Commands.Response;
using MediatR;

namespace Customer.Business.Commands.Request;

/// <summary>Create Customer Request Model</summary>
public class CreateCustomerRequest : IRequest<CreateCustomerResponse>
{
    /// <summary>Gets or sets the first name.</summary>
    /// <value>The first name.</value>
    public string FirstName { get; set; }

    /// <summary>Gets or sets the name of the middle.</summary>
    /// <value>The name of the middle.</value>
    public string MiddleName { get; set; }

    /// <summary>Gets or sets the last name.</summary>
    /// <value>The last name.</value>
    public string LastName { get; set; }

    /// <summary>Gets or sets the birth date.</summary>
    /// <value>The birth date.</value>
    public DateTime BirthDate { get; set; }

    /// <summary>Gets or sets the favorite football team.</summary>
    /// <value>The favorite football team.</value>
    public string FavoriteFootballTeam { get; set; }

    /// <summary>Gets or sets the email address.</summary>
    /// <value>The email address.</value>
    public string EmailAddress { get; set; }

    /// <summary>Gets or sets the mobile number.</summary>
    /// <value>The mobile number.</value>
    public string MobileNumber { get; set; }

    /// <summary>Gets or sets the address.</summary>
    /// <value>The address.</value>
    public string Address { get; set; }

    /// <summary>Gets or sets the address description.</summary>
    /// <value>The address description.</value>
    public string AddressDescription { get; set; }

    /// <summary>Gets or sets a value indicating whether this instance is favorite address.</summary>
    /// <value>
    ///   <c>true</c> if this instance is favorite address; otherwise, <c>false</c>.</value>
    public bool IsFavoriteAddress { get; set; }

    /// <summary>Gets or sets the name of the user.</summary>
    /// <value>The name of the user.</value>
    public string UserName { get; set; }

    /// <summary>Gets or sets the password.</summary>
    /// <value>The password.</value>
    public string Password { get; set; }

    /// <summary>Gets or sets the security question.</summary>
    /// <value>The security question.</value>
    public string SecurityQuestion { get; set; }

    /// <summary>Gets or sets the security answer.</summary>
    /// <value>The security answer.</value>
    public string SecurityAnswer { get; set; }

    /// <summary>Gets or sets a value indicating whether [applyfor account].</summary>
    /// <value>
    ///   <c>true</c> if [applyfor account]; otherwise, <c>false</c>.</value>
    public bool ApplyforAccount { get; set; }

    /// <summary>Gets or sets a value indicating whether [applyfor credit card].</summary>
    /// <value>
    ///   <c>true</c> if [applyfor credit card]; otherwise, <c>false</c>.</value>
    public bool ApplyforCreditCard { get; set; }
}
