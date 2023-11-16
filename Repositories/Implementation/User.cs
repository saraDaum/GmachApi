using Azure.Identity;
using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Implementation;

public class User : Interfaces.IUser
{

    private readonly IDbContext dbContext;
    public User(IDbContext ctx)
    {
        dbContext = ctx;
    }

    public User() {
        
    }

    /// <summary>
    /// This function gets userName and password and valid that this user already exists in system.
    /// Else, returns NULL.
    /// </summary>
    /// <param name="userName"></param>
    /// <param name="Password"></param>
    /// <returns></returns>
    public Models.User? Login(string userName, string Password)
    {
        Console.WriteLine(userName+ " " + Password);   
        return dbContext.User.Where(a => a.UserName == userName && a.UserPassword == Password).FirstOrDefault();
 
    }

    /*public int LogInUser(string userName, string Password)
    {
        try
        {
            var user = dbContext.User.Where(a => a.UserName == userName && a.UserPassword == Password).FirstOrDefault();
            if (user != null)
                return 1;
            return -1;
        }
        catch {
            return -1;
        }
    }*/



    /// <summary>
    ///This function accepts a user object and returns the first element found.
    /// If there is no matching element, returns the default value.
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    public Models.User? GetUser(LogInUser user)
    {
        return dbContext.User.FirstOrDefault(u => user.Password == u.UserPassword&& user.UserName == u.UserName);

    }




    public int SignIn(Models.User user)
    {
        try
        {
            dbContext.User.Add(user);
            dbContext.SaveChanges();
            return user.UserId;
            //TODO: check if method returns correct new userid
        }
        catch
        {
            return -1;
        }

    }

  
    public int LogInUser(string userName, string Password)
    {
        throw new NotImplementedException();
    }

    public Models.User? GetUser(Models.User? user)
    {
        try
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            else
            {
                return dbContext.User.FirstOrDefault(u => user.UserId == u.UserId && user.UserName == u.UserName);
            }
        }
        catch
        {
            return null;
        }
    }



    /* public Models.User? GetUser(Models.LogInUser? user)
   {
       return dbContext.User.Where(u => u.UserName == user.UserName && u.UserPassword == user.UserPassword).FirstOrDefault();
   }*/

}

