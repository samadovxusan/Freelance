using Application.Users.Models;
using AutoMapper;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Persistence.DataContext;
using Persistence.Repositories.Interface;

namespace Infrastructure.Common.Entity.Services;

public class AuthService(AppDbContext dbContext, IMapper mapper, IConfiguration configuration): IAuthService
{
    public async  ValueTask<bool> Register(UserDto register)
    {
        try
        {
            var user = mapper.Map<User>(register);
            await dbContext.Users.AddAsync(user);
            await dbContext.SaveChangesAsync(); 
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public async ValueTask<LoginDto> Login(Login login)
    {
        var token = new LoginDto();
        var newUser = await dbContext.Users.FirstOrDefaultAsync(x => x.Password == login.Password && x.Email == login.Email);
        if(newUser == null)
        {
            token.Succes = false;
            return token;
        }
        var jwtToken = new IdentityTokenGeneratorService(configuration);
        token.Token = await jwtToken.GenerateToken(newUser); 
        return token;
    }
}