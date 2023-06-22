using Customer.Business.Commands.Request;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Customer.API.Controllers;

/// <summary>Customer Auth Controller</summary>
[Route("api/[controller]")]
[ApiController]
public class CustomerAuthController : ControllerBase
{
    readonly IMediator mediator;

    /// <summary>Initializes a new instance of the <see cref="CustomerAuthController" /> class.</summary>
    /// <param name="mediator">The mediator.</param>
    public CustomerAuthController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    /// <summary>Logins the customer.</summary>
    /// <param name="request">The request.</param>
    /// <returns>
    ///   <br />
    /// </returns>
    [HttpPost]
    public async Task<IActionResult> LoginCustomer([FromBody] LoginCustomerRequest request)
    {
        var result = await mediator.Send(request);

        return Ok(result);
    }
}
