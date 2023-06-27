using Customer.API.Controllers;
using Customer.Business.Commands.Request;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Customer.API.Tests.Controllers;

public class CustomerAuthControllerTests
{
    [Fact()]
    public async Task LoginCustomer_ReturnsOk()
    {
        // Arrange
        var mediator = new Mock<IMediator>();
        var controller = new CustomerAuthController(mediator.Object);

        // Act
        var result = await controller.LoginCustomer(new LoginCustomerRequest());

        // Assert
        Assert.IsType<OkObjectResult>(result);
    }
}
