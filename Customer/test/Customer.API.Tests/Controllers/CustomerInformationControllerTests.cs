using Customer.API.Controllers;
using Customer.Business.Commands.Request;
using Customer.Business.Queries.Request;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Customer.API.Tests.Controllers;

public class CustomerInformationControllerTests
{
    [Fact]
    public async Task GetCustomerInformation_ReturnsOk()
    {
        // Arrange
        var mediator = new Mock<IMediator>();
        var controller = new CustomerInformationController(mediator.Object);

        // Act
        var result = await controller.GetCustomerInformation(new GetCustomerInformationRequest());

        // Assert
        Assert.IsType<OkObjectResult>(result);
    }

    [Fact]
    public async Task CreateCustomer_ReturnsOk()
    {
        // Arrange
        var mediator = new Mock<IMediator>();
        var controller = new CustomerInformationController(mediator.Object);

        // Act
        var result = await controller.CreateCustomer(new CreateCustomerRequest());

        // Assert
        Assert.IsType<OkObjectResult>(result);
    }
}
