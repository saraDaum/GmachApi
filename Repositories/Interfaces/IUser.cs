using Azure.Identity;
using Repositories.Implementation;
using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces;

public interface IUser
{
    Models.Users? Login(string userName, string Password);
    int SignIn(Models.Users? user);
    Users? GetUser(int userId);
    Users? GetUser(Models.LogInUser? user);
    int isAdmin(string email);
    List<Users> GetAll();
    bool IsUserExist(int userId);
    bool DeleteUser(Users deleteUser);    
}
