using Domain.Entities;
using Persistence.Repositories.Interface;

namespace Infrastructure.Common.Entity.Services;

public class AuthService: IAuthService
{
    public ValueTask<bool> Register(Register register)
    {
        throw new NotImplementedException();
    }

    public ValueTask<string> Login(Login login)
    {
        throw new NotImplementedException();
    }
}