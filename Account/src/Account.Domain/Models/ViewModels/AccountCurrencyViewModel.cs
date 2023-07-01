using DigitalBanking.Common.DataModels;

namespace Account.Domain.Models.ViewModels;

public class AccountCurrencyViewModel: AuditableEntity<int>
{
    public string Name { get; set; }
    public string Description { get; set; }
}
