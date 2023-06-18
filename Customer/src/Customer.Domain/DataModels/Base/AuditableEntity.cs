using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Customer.Domain.Interfaces.BaseEntity;

namespace Customer.Domain.DataModels.Base;

public class AuditableEntity<TId> : IAuditEntity<TId>
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column(Order = 0)]
    [Display(Name = "Id")]
    public TId Id { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdateDate { get; set; }

}
