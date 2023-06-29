using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using DigitalBanking.Common.Interfaces.Entity;

namespace DigitalBanking.Common.DataModels;

public class AuditableEntity<TId> : IAuditableEntity<TId>
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column(Order = 0)]
    [Display(Name = "Id")]
    public TId Id { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

}
