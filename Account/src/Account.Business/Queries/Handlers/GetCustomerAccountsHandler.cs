using Account.Business.Queries.Request;
using Account.Business.Queries.Response;
using Account.Domain.Models.ViewModels;
using Account.Infrastructure.Repositories.Interfaces;
using AutoMapper;
using MediatR;

namespace Account.Business.Queries.Handlers;

public class GetCustomerAccountsHandler: IRequestHandler<GetCustomerAccountsRequest, GetCustomerAccountsResponse>
{
    private readonly IAccountInformationRepository accountInformationRepository;
    private readonly IMapper mapper;

    public GetCustomerAccountsHandler(IAccountInformationRepository accountInformationRepository, IMapper mapper)
    {
        this.accountInformationRepository = accountInformationRepository;
        this.mapper = mapper;        
    }

    public async Task<GetCustomerAccountsResponse> Handle(GetCustomerAccountsRequest request, CancellationToken cancellationToken)
    {
        var loadedeCustomerAccounts = await accountInformationRepository.GetAllAsync(p=> p.CustomerId == request.CustomerId);

        var customerAccounts = mapper.Map<IEnumerable<AccountInformationViewModel>>(loadedeCustomerAccounts);

        return new GetCustomerAccountsResponse
        {
            CustomerAccounts = customerAccounts.ToList()
        };
    }
}

