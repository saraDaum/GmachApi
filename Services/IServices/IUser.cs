using DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IServices;

public interface IUser
{

    /// <summary>
    /// Login function
    /// Check if user Exist
    /// </summary>
    /// <param name="loginUser">user name, password</param>
    /// <returns>UserInfo or null if no user exist</returns>
    public UserInfo? Login(LoginUser loginUser);

    public int SignIn(User newUser);

    bool IsUserExists(LoginUser user);
}
