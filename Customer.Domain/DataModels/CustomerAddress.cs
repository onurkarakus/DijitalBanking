using Customer.Domain.DataModels.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Customer.Domain.DataModels;

/// <summary>Customer Address Model</summary>
[Table("CustomerAddress", Schema = "Customer")]
public class CustomerAddress: AuditableEntity<int>
{
    /// <summary>Gets or sets the customer identifier.</summary>
    /// <value>The customer identifier.</value>
    [ForeignKey("CustomerInformation")]
    public int CustomerId { get; set; }

    /// <summary>Gets or sets the type of the address.</summary>
    /// <value>The type of the address.</value>
    public string AddressType { get; set; }

    /// <summary>Gets or sets the address.</summary>
    /// <value>The address.</value>
    public string Address { get; set; }

    /// <summary>Gets or sets the country.</summary>
    /// <value>The country.</value>
    public string Country { get; set; }

    /// <summary>Gets or sets the city.</summary>
    /// <value>The city.</value>
    public string City { get; set; }

    /// <summary>Gets or sets the district.</summary>
    /// <value>The district.</value>
    public string District { get; set; }

    /// <summary>Gets or sets the address description.</summary>
    /// <value>The address description.</value>
    [MaxLength(200)]
    public string AddressDescription { get; set; }

    /// <summary>Gets or sets a value indicating whether this instance is favorite address.</summary>
    /// <value>
    ///   <c>true</c> if this instance is favorite address; otherwise, <c>false</c>.</value>
    public bool IsFavoriteAddress { get; set; }
}
