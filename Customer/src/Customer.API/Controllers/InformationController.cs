using Customer.Business.Queries.Request;
using Customer.Business.Queries.Response;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Customer.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class InformationController : ControllerBase
{
    readonly IMediator mediator;


    public InformationController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetCustomerInformation([FromBody] GetCustomerInformationRequest request)
    {
        var result = await mediator.Send(request);

        return Ok(result);
    }
}
