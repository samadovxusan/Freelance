using Applaication.Common.Identity.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Api;

[Route("api/[controller]/[action]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService  _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var users =  _userService.Get();
        return Ok(users);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var user = _userService.GetByIdAsync(id);
        return Ok(user);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] User user)
    {
        var result = await _userService.CreateAsync(user);
        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> Put([FromBody] User user)
    {
        var result = await _userService.UpdateAsync(user);
        return Ok(result);
    }
}