using Customer.Business.Commands.Request;
using Customer.Business.Commands.Response;
using Customer.Domain.DataModels;
using Customer.Domain.Exceptions;
using Customer.Domain.Interfaces.Services;
using Customer.Domain.Interfaces.Utilities;
using Customer.Infrastructure.Repositories.Interfaces;
using DigitalBanking.Common.Exceptions;
using MediatR;

namespace Customer.Business.Commands.Handlers;

/// <summary>Login Customer Handler</summary>
public class LoginCustomerHandler : IRequestHandler<LoginCustomerRequest, LoginCustomerResponse>
{
    private readonly ICustomerSecurityRespository customerSecurityRespository;
    private readonly ICryptographyUtility cryptographyUtility;
    private readonly ITokenService tokenService;

    /// <summary>Initializes a new instance of the <see cref="LoginCustomerHandler" /> class.</summary>
    /// <param name="customerSecurityRespository">The customer security respository.</param>
    /// <param name="cryptographyUtility">The cryptography utility.</param>
    /// <param name="tokenService">The token service.</param>
    public LoginCustomerHandler(
        ICustomerSecurityRespository customerSecurityRespository, 
        ICryptographyUtility cryptographyUtility,
        ITokenService tokenService)
    {
        this.customerSecurityRespository = customerSecurityRespository;
        this.cryptographyUtility = cryptographyUtility;
        this.tokenService = tokenService;
    }

    /// <summary>Handles a request</summary>
    /// <param name="request">The request</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Response from the request</returns>
    /// <exception cref="DigitalBanking.Common.Exceptions.NotFoundException">CustomerSecurity</exception>
    /// <exception cref="Customer.Domain.Exceptions.InvalidPasswordException">CustomerSecurity</exception>
    public async Task<LoginCustomerResponse> Handle(LoginCustomerRequest request, CancellationToken cancellationToken)
    {
        var loadedCustomer = await customerSecurityRespository.GetAsync(p => p.UserName == request.UserName) ?? throw new NotFoundException(nameof(CustomerSecurity), request.UserName);

        if (!cryptographyUtility.Compare(request.Password, loadedCustomer.PasswordSalt, loadedCustomer.Password))
        {
            loadedCustomer.FailedLoginAttempts++;            
            await customerSecurityRespository.UpdateAsync(loadedCustomer);

            throw new InvalidPasswordException(nameof(CustomerSecurity), request.UserName);
        }

        loadedCustomer.LastLoginDateTime = DateTime.Now;
        await customerSecurityRespository.UpdateAsync(loadedCustomer);

        var createdTokenInformation = await tokenService.GenerateToken(new Domain.Models.Requests.GenerateTokenRequest { Username = loadedCustomer.UserName });       

        return new LoginCustomerResponse
        {
            CustomerId = loadedCustomer.CustomerId,
            Token = createdTokenInformation.Token,
            TokenExpireDate = createdTokenInformation.TokenExpireDate
        };
    }
}
