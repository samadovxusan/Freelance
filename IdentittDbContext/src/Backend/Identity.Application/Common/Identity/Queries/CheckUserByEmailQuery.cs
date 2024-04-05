using Identity.Domain.Queries;

namespace Identity.Application.Common.Identity.Commands;

public class CheckUserByEmailQuery:IQuery<string>
{
    public string Email { get; set; }
}