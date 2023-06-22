using AutoMapper;
using Customer.Business.Queries.Request;
using Customer.Business.Queries.Response;
using Customer.Domain.DataModels;
using Customer.Domain.Exceptions;
using Customer.Domain.Interfaces.Respoistories;
using Customer.Domain.Models;
using Customer.Infrastructure;
using Customer.Infrastructure.DbContextInformation;
using MediatR;

namespace Customer.Business.Queries.Handlers;

/// <summary>Get Customer Information Handler</summary>
public class GetCustomerInformationHandler : IRequestHandler<GetCustomerInformationRequest, GetCustomerInformationResponse>
{
    private readonly ICustomerInformationRespository _customerInformationRepository;
    private readonly IMapper _mapper;
    private readonly UnitOfWork<int> _unitOfWork;

    /// <summary>Initializes a new instance of the <see cref="GetCustomerInformationHandler" /> class.</summary>
    /// <param name="_customerDbContext">The customer database context.</param>
    /// <param name="customerInformationRepository">The customer information repository.</param>
    /// <param name="mapper">The mapper.</param>
    public GetCustomerInformationHandler(CustomerDbContext _customerDbContext, ICustomerInformationRespository customerInformationRepository, IMapper mapper)
    {
        _customerInformationRepository = customerInformationRepository;
        _mapper = mapper;
        _unitOfWork = new UnitOfWork<int>(_customerDbContext);
    }

    /// <summary>Handles a request</summary>
    /// <param name="request">The request</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Response from the request</returns>
    /// <exception cref="Customer.Domain.Exceptions.NotFoundException">CustomerInformation</exception>
    public async Task<GetCustomerInformationResponse> Handle(GetCustomerInformationRequest request, CancellationToken cancellationToken)
    {
        var customerInformation = await _customerInformationRepository.GetByIdAsync(request.CustomerId) ?? throw new NotFoundException(nameof(CustomerInformation), request.CustomerId);
        var customerInformationDto = _mapper.Map<CustomerInformationDto>(customerInformation);

        return new GetCustomerInformationResponse
        {
            CustomerInformation = customerInformationDto
        };
    }
}
