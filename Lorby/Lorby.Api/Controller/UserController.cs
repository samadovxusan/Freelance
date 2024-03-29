using Application.Users.Models;
using Application.Users.UserSevices;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Lorby.Api.Controller;

[Route("api/[controller]/[action]")]
[ApiController]
public class UserController(IUserService userService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetUsers()
    {
        var users = await userService.GetUsers();
        return Ok(users);
    }

    [HttpGet]
    public async Task<IActionResult> GetById(Guid id)
    {
        var users = await userService.GetByIdAsync(id);
        return Ok(users);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] UserDto user, CancellationToken cancellationToken = default)
    {
        var result = await userService.CreateAsync(user, cancellationToken);
        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromForm] UserDto user, Guid id, CancellationToken cancellationToken = default)
    {
        var result = await userService.UpdateAsync(user, id, cancellationToken);
        return Ok(result);
    }
    [HttpDelete]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await userService.DeleteAsync(id);
        return Ok(result);
    }
}