using Customer.Domain.DataModels.Base;

namespace Customer.Domain.Models;

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
    public string FavoriteTeam { get; set; }
}
