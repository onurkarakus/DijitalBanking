using AutoMapper;
using Customer.Business.Commands.Request;
using Customer.Business.Commands.Response;
using Customer.Domain.Interfaces.Respoistories;
using Customer.Infrastructure.DbContextInformation;
using Customer.Infrastructure;
using MediatR;
using Customer.Domain.DataModels;
using Customer.Domain.Interfaces.Utilities;

namespace Customer.Business.Commands.Handlers;

/// <summary>Create Customer Handler</summary>
public class CreateCustomerHandler : IRequestHandler<CreateCustomerRequest, CreateCustomerResponse>
{
    private readonly ICustomerInformationRespository customerInformationRepository;
    private readonly ICustomerSecurityRespository customerSecurityRespository;
    private readonly IMapper mapper;
    private readonly ICryptographyUtility cryptographyUtility;
    private readonly UnitOfWork<int> unitOfWork;

    /// <summary>Initializes a new instance of the <see cref="CreateCustomerHandler" /> class.</summary>
    /// <param name="customerDbContext">The customer database context.</param>
    /// <param name="customerInformationRepository">The customer information repository.</param>
    /// <param name="customerSecurityRespository">The customer security respository.</param>
    /// <param name="mapper">The mapper.</param>
    /// <param name="cryptographyUtility">The cryptography utility.</param>
    public CreateCustomerHandler(
        CustomerDbContext customerDbContext,
        ICustomerInformationRespository customerInformationRepository,
        ICustomerSecurityRespository customerSecurityRespository,
        IMapper mapper,
        ICryptographyUtility cryptographyUtility)
    {
        this.customerInformationRepository = customerInformationRepository;
        this.customerSecurityRespository = customerSecurityRespository;
        this.mapper = mapper;
        this.cryptographyUtility = cryptographyUtility;
        unitOfWork = new UnitOfWork<int>(customerDbContext);

    }

    /// <summary>Handles a request</summary>
    /// <param name="request">The request</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Response from the request</returns>
    public async Task<CreateCustomerResponse> Handle(CreateCustomerRequest request, CancellationToken cancellationToken)
    {
        var createCustomerResult = await customerInformationRepository.AddAsync(new CustomerInformation
        {
            FirstName = request.FirstName,
            MiddleName = request.MiddleName,
            LastName = request.LastName,
            BirthDate = request.BirthDate,
            FavoriteFootballTeam = request.FavoriteFootballTeam,
            EmailAddress = request.EmailAddress,
            MobileNumber = request.MobileNumber,
            Address = request.Address,
            AddressDescription = request.AddressDescription,
            IsFavoriteAddress = request.IsFavoriteAddress,
            CreatedBy = "System",
            CreatedDate = DateTime.Now,
            UpdatedBy = "System",
            UpdatedDate = DateTime.Now

        }, cancellationToken);

        var customerSecurityentity = new CustomerSecurity
        {
            CustomerInformation = createCustomerResult,
            UserName = request.UserName,
            SecurityQuestion = request.SecurityQuestion,
            SecurityAnswer = request.SecurityAnswer,
            CreatedBy = "System",
            CreatedDate = DateTime.Now,
            UpdatedBy = "System",
            UpdatedDate = DateTime.Now,
            PasswordSalt = cryptographyUtility.CreateSalt(),
        };

        customerSecurityentity.Password = cryptographyUtility.EncryptWithSalt(request.Password, customerSecurityentity.PasswordSalt);

        _ = await customerSecurityRespository.AddAsync(customerSecurityentity, cancellationToken);

        var commitResult = await unitOfWork.CommitAsync(cancellationToken);

        return new CreateCustomerResponse() { CustomerId = createCustomerResult.Id, CustomerCreated = commitResult > 0 };
    }
}
