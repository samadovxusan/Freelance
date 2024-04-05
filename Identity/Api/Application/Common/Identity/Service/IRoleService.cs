using Domain.Common.Entities;
using Domain.Enum;

namespace Application.Common.Service;

public interface IRoleService
{
    ValueTask<Role?> GetByTypeAsync(RoleType roleType, bool asNoTracking = false, CancellationToken cancellationToken = default);    
}