using DigitalBanking.Common.DataModels;
using System.ComponentModel.DataAnnotations.Schema;

namespace Account.Domain.DataModels;

[Table("AccountInformation", Schema = "Account")]
public class AccountInformation:AuditableEntity<int>
{
    public int CustomerId { get; set; }

    public int BranchCode { get; set; }

    public string AccountNumber { get; set; }

    public string Suffix { get; set; }

    [ForeignKey("AccountType")]
    public int AccountTypeId { get; set; }

    public AccountType AccountType { get; set; }

    [ForeignKey("AccountCurrency")]
    public int AccountCurrencyId { get; set; }

    public AccountCurrency AccountCurrency { get; set; }

    public int Balance { get; set; }

    public bool AccountActive { get; set; }
}
