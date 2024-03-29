using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Persistence.Repositories.Interface;

namespace Lorby.Api.Controller;

[Route("api/[controller]/[action]")]
[ApiController]
public class AuthController(IAuthService authService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Register(Register register)
    {
        var result = await authService.Register(register);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Login(Login login)
    {
        var result = await authService.Login(login);
        return Ok(result);
    }

}