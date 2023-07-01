using Account.Business.Queries.Request;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Account.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly IMediator mediator;

    public AccountController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet("GetAccountCurrencies")]
    public async Task<IActionResult> GetAccountCurrencies()
    {
        var result = await mediator.Send(new GetAccountCurrenciesRequest());

        return Ok(result);
    }

    [HttpGet("GetAccountTypes")]
    public async Task<IActionResult> GetAccountTypes()
    {
        var result = await mediator.Send(new GetAccountTypesRequest());

        return Ok(result);
    }

    [HttpGet("GetCustomerAccounts")]
    public async Task<IActionResult> GetCustomerAccounts([FromQuery] GetCustomerAccountsRequest request)
    {
        var result = await mediator.Send(request);

        return Ok(result);
    }
}
