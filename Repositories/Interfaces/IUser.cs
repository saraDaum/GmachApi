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
    public Models.User? Login(string userName, string Password);
    public int SignIn(Models.User? user);
    public Models.User GetUser(Models.User? user);
    public Models.User GetUser(string UserName, string UserPassword);

  
    

}
