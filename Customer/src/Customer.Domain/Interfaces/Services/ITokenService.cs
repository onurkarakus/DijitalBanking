using Customer.Domain.Models.Requests;
using Customer.Domain.Models.Responses;

namespace Customer.Domain.Interfaces.Services;

public interface ITokenService
{
    public Task<GenerateTokenResponse> GenerateToken(GenerateTokenRequest request);
}
