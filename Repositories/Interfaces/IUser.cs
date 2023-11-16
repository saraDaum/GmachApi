using Azure.Identity;
using Repositories.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces;

public interface IUser
{
    public Models.Users? Login(string userName, string Password);
    public int LogInUser(string userName, string Password);
    public int SignIn(Models.Users? user);
    public Models.Users GetUser(Models.Users? user);
    public Models.Users? GetUser(Models.LogInUser? user);

  
    

}
