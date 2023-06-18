namespace Customer.Domain.Interfaces.BaseEntity;

public interface IAuditEntity<TId> : IAuditableEntity, IEntity<TId>
{

}

public interface IAuditableEntity
{
    string? CreatedBy { get; set; }
    DateTime CreatedDate { get; set; }
    string? UpdatedBy { get; set; }
    DateTime? UpdateDate { get; set; }
}

