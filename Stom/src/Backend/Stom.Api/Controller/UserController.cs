using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stom.Application.Users.Commands;
using Stom.Application.Users.Queries;
using Stom.Persistence.DbContexts;

namespace Stom.Api.Controller;

[ApiController]
[Route("api/[controller]")]
public class UserController (IMediator mediator,AppDbContext appDbContext): ControllerBase
{
    [HttpGet]
    public async ValueTask<IActionResult> Get()
    {
        var result = await appDbContext.Users.ToListAsync();
        return Ok(result);
    }
    [HttpGet ("{userid:guid}")]
    public async ValueTask<IActionResult> GetById([FromQuery] GetByIdUserQuery usersQuery,CancellationToken cancellationToken = default)
    {
        var result = await mediator.Send(usersQuery, cancellationToken);
        return result is not null ? Ok(result) : BadRequest();
    }
    
    
    [HttpPost]
    public async ValueTask<IActionResult> Create([FromBody] CreateUserCommand userCommand,
        CancellationToken cancellationToken = default)
    {
        var result = await mediator.Send(userCommand, cancellationToken); 
        return result is not null ? Ok(result) : BadRequest();

    }
    [HttpPut]
    public async ValueTask<IActionResult> Update([FromBody] UpdateUserCommand userCommand,
        CancellationToken cancellationToken = default)
    {
        var result = await mediator.Send(userCommand, cancellationToken);
        return result is not null ? Ok(result) : BadRequest();
        
    }
    [HttpDelete("{userid:guid}")]
    public async ValueTask<IActionResult> Delete([FromBody] DeleteUserCommand userCommand,
        CancellationToken cancellationToken = default)
    {
        var result = await mediator.Send(userCommand, cancellationToken);
        return  Ok(result);
        
    }
}