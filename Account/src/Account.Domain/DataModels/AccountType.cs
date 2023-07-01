using DigitalBanking.Common.DataModels;
using System.ComponentModel.DataAnnotations.Schema;

namespace Account.Domain.DataModels;

[Table("AccountType", Schema = "Account")]
public class AccountType : AuditableEntity<int>
{
    public string Name { get; set; }

    public string Description { get; set; }
}
