using Account.Domain.Models.ViewModels;

namespace Account.Business.Queries.Response;

public class GetAccountTypesResponse
{
    public List<AccountTypeViewModel> AccountTypes { get; set; }

    public GetAccountTypesResponse()
    {
        AccountTypes = new List<AccountTypeViewModel>();
    }
}
