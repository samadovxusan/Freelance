using AutoMapper;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Persistence.DataContext;
using Persistence.Repositories.Interface;

namespace Infrastructure.Common.Entity.Services;

public class AuthService(AppDbContext dbContext, IMapper mapper, IConfiguration configuration): IAuthService
{
    public async  ValueTask<bool> Register(Register register)
    {
        try
        {
            var user = mapper.Map<User>(register);
            await dbContext.Users.AddAsync(user);
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public async ValueTask<string> Login(Login login)
    {
        var newUser = await dbContext.Users.FirstOrDefaultAsync(x => x.Password == login.Password && x.Email == login.Email);
        if(newUser == null) 
        {
            return "Not Faund User";
        }
        var jwtToken = new IdentityTokenGeneratorService(configuration);
        var resust = jwtToken.GenerateToken(newUser);
        return await resust;
    }
}