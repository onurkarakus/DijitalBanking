using Customer.Business.Commands.Request;
using Customer.Business.Queries.Request;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Customer.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomerInformationController : ControllerBase
{
    readonly IMediator mediator;

    public CustomerInformationController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetCustomerInformation([FromQuery] GetCustomerInformationRequest request)
    {
        var result = await mediator.Send(request);

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerRequest request)
    {
        var result = await mediator.Send(request);

        return Ok(result);
    }
}
