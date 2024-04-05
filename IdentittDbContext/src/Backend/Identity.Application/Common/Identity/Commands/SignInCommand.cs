using System.Windows.Input;
using Identity.Application.Common.Identity.Models;
using Identity.Domain.Common.Commands;
using Identity.Domain.Common.Entities;

namespace Identity.Application.Common.Identity.Commands;

public class SignInCommand: ICommand<User>
{
    public SingInDetails SignInDetails { get; set; }    
}