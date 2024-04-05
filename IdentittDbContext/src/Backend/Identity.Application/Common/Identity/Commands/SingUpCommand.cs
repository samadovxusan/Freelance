using Identity.Application.Common.Identity.Models;
using Identity.Domain.Common.Commands;

namespace Identity.Application.Common.Identity.Commands;

public class SingUpCommand:ICommand<string>
{
    public SingUpDetails SingUpDetails { get; set; }
}