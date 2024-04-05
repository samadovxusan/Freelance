using Identity.Application.Common.Identity.Commands;
using Identity.Application.Common.Identity.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Identity.Api.Controller;



[Route("api/[controller]/[action]")]
[ApiController]
public class AuthController (IMediator mediator): ControllerBase
{
    [HttpPost("Register")]
    public async Task<IActionResult> Register(SingInDetails sender, CancellationToken cancellationToken = default)
    {
        var result = await mediator.Send(sender,cancellationToken);
        return Ok(result);
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login(SingUpCommand singUpCommand, CancellationToken cancellationToken = default)
    {
        var result = await mediator.Send(singUpCommand,cancellationToken);
        return Ok(result);
    }
}