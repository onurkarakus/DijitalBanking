using Customer.Business.Services;
using Customer.Domain.Models.Requests;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Customer.API.Tests.Services;

public class TokenServiceTests
{
    [Fact]
    public async Task GenerateToken()
    {
        // Arrange
        var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

        var tokenService = new TokenService(configuration);

        var request = new GenerateTokenRequest
        {
            Username = "test"
        };

        // Act
        var response = await tokenService.GenerateToken(request);

        // Assert
        Assert.NotNull(response);
        Assert.NotNull(response.Token);
        Assert.NotNull(response.TokenExpireDate);
    }
}
