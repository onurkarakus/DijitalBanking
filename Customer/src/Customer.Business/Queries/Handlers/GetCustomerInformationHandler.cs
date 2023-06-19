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

public class GetCustomerInformationHandler : IRequestHandler<GetCustomerInformationRequest, GetCustomerInformationResponse>
{
    private readonly CustomerDbContext _customerDbContext;
    private readonly ICustomerInformationRespository _customerInformationRepository;
    private readonly IMapper _mapper;
    private readonly UnitOfWork<int> _unitOfWork;

    public GetCustomerInformationHandler(CustomerDbContext _customerDbContext, ICustomerInformationRespository customerInformationRepository, IMapper mapper)
    {
        _customerInformationRepository = customerInformationRepository;
        _mapper = mapper;
        _unitOfWork = new UnitOfWork<int>(_customerDbContext);
    }

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
