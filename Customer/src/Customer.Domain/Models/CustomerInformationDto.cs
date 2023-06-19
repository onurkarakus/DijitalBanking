using Customer.Domain.DataModels.Base;

namespace Customer.Domain.Models;

/// <summary>Customer Information Dto</summary>
public class CustomerInformationDto: AuditableEntity<int>
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

    /// <summary>Gets or sets the favorite team.</summary>
    /// <value>The favorite team.</value>
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
}
