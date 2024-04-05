using Identity.Domain.Common.Commands;
using Identity.Domain.Common.Entities;
using Identity.Domain.Enums;

namespace Identity.Application.Common.Identity.Models;

public class SingInDetails : ICommand<User>
{
      public string Name { get; set; }
      public string Email { get; set; }
      public string Password { get; set; }
      public Role Role { get; set; }
}