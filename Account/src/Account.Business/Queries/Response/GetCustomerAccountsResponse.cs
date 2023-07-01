using Account.Domain.Models.ViewModels;

namespace Account.Business.Queries.Response;

public class GetCustomerAccountsResponse
{
    public List<AccountInformationViewModel> CustomerAccounts { get; set; }

    public GetCustomerAccountsResponse()
    {
        CustomerAccounts = new List<AccountInformationViewModel>();
    }
}
