using AutoMapper;
using Customer.Business.Queries.Request;
using Customer.Business.Queries.Response;
using Customer.Domain.DataModels;
using Customer.Domain.Models.ViewModels;
using Customer.Infrastructure.Repositories.Interfaces;
using DigitalBanking.Common.Exceptions;
using MediatR;

namespace Customer.Business.Queries.Handlers;

/// <summary>Get Customer Information Handler</summary>
public class GetCustomerInformationHandler : IRequestHandler<GetCustomerInformationRequest, GetCustomerInformationResponse>
{
    private readonly ICustomerInformationRespository _customerInformationRepository;
    private readonly IMapper _mapper;

    /// <summary>Initializes a new instance of the <see cref="GetCustomerInformationHandler" /> class.</summary>
    /// <param name="_customerDbContext">The customer database context.</param>
    /// <param name="customerInformationRepository">The customer information repository.</param>
    /// <param name="mapper">The mapper.</param>
    public GetCustomerInformationHandler(ICustomerInformationRespository customerInformationRepository, IMapper mapper)
    {
        _customerInformationRepository = customerInformationRepository;
        _mapper = mapper;
    }

    /// <summary>Handles a request</summary>
    /// <param name="request">The request</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Response from the request</returns>
    /// <exception cref="DigitalBanking.Common.Exceptions.NotFoundException">CustomerInformation</exception>
    public async Task<GetCustomerInformationResponse> Handle(GetCustomerInformationRequest request, CancellationToken cancellationToken)
    {
        var customerInformation = await _customerInformationRepository.GetByIdAsync(request.CustomerId) ?? throw new NotFoundException(nameof(CustomerInformation), request.CustomerId);
        var customerInformationDto = _mapper.Map<CustomerInformationViewModel>(customerInformation);

        return new GetCustomerInformationResponse
        {
            CustomerInformation = customerInformationDto
        };
    }
}
