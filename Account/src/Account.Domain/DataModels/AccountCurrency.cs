using DigitalBanking.Common.DataModels;
using System.ComponentModel.DataAnnotations.Schema;

namespace Account.Domain.DataModels;

[Table("AccountCurrency", Schema = "Account")]
public class AccountCurrency: AuditableEntity<int>
{
    public string Name { get; set; }
    public string Description { get; set; }
}
