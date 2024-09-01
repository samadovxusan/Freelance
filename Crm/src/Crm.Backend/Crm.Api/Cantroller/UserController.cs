using Crm.Application.Users.Commands;
using Crm.Application.Users.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Crm.Api.Cantroller;
[ApiController]
[Route("api/[controller]")]
public class UserController (IMediator mediator): ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] UserGetQueries userGetQuery, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(userGetQuery, cancellationToken);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new UserGetByIdQueries() {Id = id}, cancellationToken);
        return result is not null ? Ok(result) : NoContent();
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] UserCreateCommand userCreateCommand)
    {
        var result = await mediator.Send(userCreateCommand);
        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UserUpdateCommand userCreateCommand,
        CancellationToken cancellationToken)
    {
        var result = await mediator.Send(userCreateCommand, cancellationToken);
        return Ok(result);
    }
    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] Guid id, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(id, cancellationToken);
        return Ok(result);
        
    }
    
    
    
}