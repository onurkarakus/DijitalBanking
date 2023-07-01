using Account.Business.Queries.Request;
using Account.Business.Queries.Response;
using Account.Domain.Models.ViewModels;
using Account.Infrastructure.Repositories.Interfaces;
using AutoMapper;
using MediatR;

namespace Account.Business.Queries.Handlers;

public class GetAccountTypesHandler : IRequestHandler<GetAccountTypesRequest, GetAccountTypesResponse>
{
    private readonly IAccountTypeRepository accountTypeRepository;
    private readonly IMapper mapper;

    public GetAccountTypesHandler(IAccountTypeRepository accountTypeRepository, IMapper mapper)
    {
        this.accountTypeRepository = accountTypeRepository;
        this.mapper = mapper;
    }

    public async Task<GetAccountTypesResponse> Handle(GetAccountTypesRequest request, CancellationToken cancellationToken)
    {
        var accountTypes = await accountTypeRepository.GetAllAsync();
        var accountTypesDto = mapper.Map<IEnumerable<AccountTypeViewModel>>(accountTypes);

        return new GetAccountTypesResponse
        {
            AccountTypes = accountTypesDto.ToList()
        };
    }
}
