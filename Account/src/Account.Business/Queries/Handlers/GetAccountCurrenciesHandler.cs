using Account.Business.Queries.Request;
using Account.Business.Queries.Response;
using Account.Domain.Models.ViewModels;
using Account.Infrastructure.Repositories.Interfaces;
using AutoMapper;
using MediatR;

namespace Account.Business.Queries.Handlers;

public class GetAccountCurrenciesHandler: IRequestHandler<GetAccountCurrenciesRequest, GetAccountCurrenciesResponse>
{
    private readonly IAccountCurrencyRepository accountCurrencyRepository;
    private readonly IMapper mapper;

    public GetAccountCurrenciesHandler(IAccountCurrencyRepository accountCurrencyRepository, IMapper mapper)
    {
        this.accountCurrencyRepository = accountCurrencyRepository;
        this.mapper = mapper;
    }

    public async Task<GetAccountCurrenciesResponse> Handle(GetAccountCurrenciesRequest request, CancellationToken cancellationToken)
    {
        var accountCurrencyInformations = await accountCurrencyRepository.GetAllAsync();

        var accountCurrencyInformationsDto = mapper.Map<IEnumerable<AccountCurrencyViewModel>>(accountCurrencyInformations);

        return new GetAccountCurrenciesResponse
        {
            AccountCurrencies = accountCurrencyInformationsDto.ToList()
        };
    }
}
