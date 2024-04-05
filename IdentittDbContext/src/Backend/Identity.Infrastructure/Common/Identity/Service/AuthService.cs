using System.Security.Claims;
using Identity.Application.Common.Identity.Models;
using Identity.Application.Common.Identity.Service;
using Identity.Domain.Common.Entities;
using Identity.Persistence.Repositories.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Identity.Persistence.DataContext;

public class AuthService(IUserRepository userRepository,UserManager<User> userManager,RoleManager<IdentityRole> roleManager,AppDbContext appDbContext):IAuthService
{
    public async ValueTask<string> SignUpAsync(SingUpDetails signUpDetails, CancellationToken cancellationToken = default)
    {
        var user = await  appDbContext.Users.FirstOrDefaultAsync(u => u.Email == signUpDetails.Email);
        if (user != null)
        {
            var Roles = await userManager.GetRolesAsync(user);
            var RoleClaims = Roles.Select(role => new Claim(ClaimTypes.Role, role)).ToList();
            RoleClaims.Add(new Claim(ClaimTypes.Name, signUpDetails.Name));
            var token = CreateTokenInJwtAuthorizationFromUsers.CreateToken(user, RoleClaims);
            return token;
        }

        throw new BadHttpRequestException("User not found");

    }

    public async ValueTask<User> SignInAsync(SingInDetails signInDetails, CancellationToken cancellationToken = default)
    {
        var user = new User
        {
            Id = new Guid(),
            UserName = signInDetails.Name,
            Email = signInDetails.Email,
        };
        
        
        var result = await userManager.CreateAsync(user, signInDetails.Password);
        if (!result.Succeeded)
        {
            throw new Exception(result.Errors.First().Description);
        }

        await userManager.AddToRoleAsync(user, Enum.GetName(signInDetails.Role).ToUpper());
        await appDbContext.SaveChangesAsync();
        return user;
    }
}