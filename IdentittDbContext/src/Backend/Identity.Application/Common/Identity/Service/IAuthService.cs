using Identity.Application.Common.Identity.Models;
using Identity.Domain.Common.Entities;

namespace Identity.Application.Common.Identity.Service;

public interface IAuthService
{
    ValueTask<string> SignUpAsync(
        SingUpDetails signUpDetails, 
        CancellationToken cancellationToken = default);
    
    ValueTask<User> SignInAsync(
        SingInDetails signInDetails, 
        CancellationToken cancellationToken = default);
}