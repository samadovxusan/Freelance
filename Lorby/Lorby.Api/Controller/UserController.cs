using Application.Users.Models;
using Application.Users.UserSevices;
using Domain.Entities;
using Lorby.Api.Extentions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lorby.Api.Controller;

[Route("api/[controller]/[action]")]
[ApiController]
[Authorize]
public class UserController(IUserService userService,IWebHostEnvironment _webHostEnvironment) : ControllerBase
{
    [HttpGet]
    [ResponseCache(Duration = 40)]
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
    public async Task<IActionResult> Post([FromForm] UserDto user, IFormFile imageUrl, CancellationToken cancellationToken = default)
    {
        var Extention = new MethodExtention(_webHostEnvironment);
        var picturepath = await Extention.AddPictureAndGetPath(imageUrl);
        var result = await userService.CreateAsync(user,picturepath, cancellationToken);
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