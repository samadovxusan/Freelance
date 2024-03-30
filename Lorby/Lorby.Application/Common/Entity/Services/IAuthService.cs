using Application.Users.Models;
using Domain.Entities;

namespace Persistence.Repositories.Interface;

public interface IAuthService
{
    ValueTask<Boolean> Register (UserDto register);
    ValueTask<string> Login (Login login);
}