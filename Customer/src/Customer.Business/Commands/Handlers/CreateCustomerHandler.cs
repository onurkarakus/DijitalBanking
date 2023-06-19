using AutoMapper;
using Customer.Business.Commands.Request;
using Customer.Business.Commands.Response;
using Customer.Domain.Interfaces.Respoistories;
using Customer.Infrastructure.DbContextInformation;
using Customer.Infrastructure;
using MediatR;

namespace Customer.Business.Commands.Handlers;

public class CreateCustomerHandler : IRequestHandler<CreateCustomerRequest, CreateCustomerResponse>
{
    private readonly ICustomerInformationRespository customerInformationRepository;
    private readonly IMapper mapper;
    private readonly UnitOfWork<int> unitOfWork;

    public CreateCustomerHandler(CustomerDbContext customerDbContext, ICustomerInformationRespository customerInformationRepository, IMapper mapper)
    {
        this.customerInformationRepository = customerInformationRepository;
        this.mapper = mapper;
        this.unitOfWork = new UnitOfWork<int>(customerDbContext);
    }

    public Task<CreateCustomerResponse> Handle(CreateCustomerRequest request, CancellationToken cancellationToken)
    {
        return Task.FromResult(new CreateCustomerResponse());
    }
}
