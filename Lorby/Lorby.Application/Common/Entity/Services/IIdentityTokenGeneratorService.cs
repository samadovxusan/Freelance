using System.Security.Claims;
using Domain.Entities;

namespace Persistence.Repositories;

public interface IIdentityTokenGeneratorService
{
    Task<string> GenerateToken(User user);
    Task<string> GenerateToken(IEnumerable<Claim> additionalClaims);
    
}