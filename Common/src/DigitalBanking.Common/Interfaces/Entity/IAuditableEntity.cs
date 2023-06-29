namespace DigitalBanking.Common.Interfaces.Entity;

/// <summary>AuditableEntity Interface</summary>
/// <typeparam name="TId">The type of the identifier.</typeparam>
public interface IAuditableEntity<TId> : IAuditableEntity, IEntity<TId>
{

}

/// <summary>Auditable Entity Interface</summary>
public interface IAuditableEntity
{
    /// <summary>Gets or sets the created by.</summary>
    /// <value>The created by.</value>
    string? CreatedBy { get; set; }

    /// <summary>Gets or sets the created date.</summary>
    /// <value>The created date.</value>
    DateTime CreatedDate { get; set; }

    /// <summary>Gets or sets the updated by.</summary>
    /// <value>The updated by.</value>
    string? UpdatedBy { get; set; }

    /// <summary>Gets or sets the updated date.</summary>
    /// <value>The updated date.</value>
    DateTime? UpdatedDate { get; set; }
}

