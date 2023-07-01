namespace Account.Domain.Models.ViewModels;

public class AccountInformationViewModel
{
    public int CustomerId { get; set; }

    public int BranchCode { get; set; }

    public string AccountNumber { get; set; }

    public string Suffix { get; set; }

    public int AccountTypeId { get; set; }

    public AccountTypeViewModel AccountType { get; set; }

    public int AccountCurrencyId { get; set; }

    public AccountCurrencyViewModel AccountCurrency { get; set; }

    public int Balance { get; set; }

    public bool AccountActive { get; set; }
}
