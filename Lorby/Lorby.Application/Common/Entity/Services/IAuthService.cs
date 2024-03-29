using Domain.Entities;

namespace Persistence.Repositories.Interface;

public interface IAuthService
{
    ValueTask<Boolean> Register (Register register);
    ValueTask<string> Login (Login login);
}