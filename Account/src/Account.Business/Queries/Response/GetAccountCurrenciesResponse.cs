using Account.Domain.Models.ViewModels;

namespace Account.Business.Queries.Response;

public class GetAccountCurrenciesResponse
{
    public List<AccountCurrencyViewModel> AccountCurrencies { get; set; }

    public GetAccountCurrenciesResponse()
    {
        AccountCurrencies = new List<AccountCurrencyViewModel>();
    }
}
