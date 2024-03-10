using Azure.Identity;
using Microsoft.EntityFrameworkCore;
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

    //Constructors
    public User(IDbContext ctx)
    {
        dbContext = ctx;
    }
    public User() {
        dbContext = new GmachimSaraAndShaniContext();
    }


    /// <summary>
    /// This function gets userName and password and valid that this user already exists in system.
    /// Else, returns NULL.
    /// </summary>
    /// <param name="userName"></param>
    /// <param name="Password"></param>
    /// <returns></returns>
    public Models.Users? Login(string userName, string Password)
    {
        try
        {
            //Console.WriteLine(userName + " " + Password);
            return dbContext.Users.Where(a => a.UserName == userName && a.UserPassword == Password).FirstOrDefault();
        }
        catch (Exception)
        {
            return null;
        }
    }

    


    /// <summary>
    ///This function gets an user object and returns the first element found.
    /// If there is no matching element, returns the default value.
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    public Models.Users? GetUser(LogInUser user)
    {
        try
        {

            return dbContext.Users.FirstOrDefault(u => user.Password == u.UserPassword && user.UserName == u.UserName);
        }
        catch (Exception)
        {
            return null;
        }

    }

    public Users? GetUser(int userID)
    {
        try
        {
            return dbContext.Users.FirstOrDefault(user => user.UserId == userID);
        }
        catch
        {
            return null;
        }
    }

    /// <summary>
    /// Get user and add it to the database
    /// </summary>
    /// <param name="user"> the user </param>
    /// <returns>the user id or -1 in case of error </returns>
    public int SignIn(Models.Users user)
    {
        try
        {
            dbContext.Users.Add(user);
            try
            {
                dbContext.SaveChanges();
            }
            catch {
                return -6;
            }
            return user.UserId;
            //TODO: check if method returns correct new userid
        }
        catch
        {
            return -1;
        }


    }

    public bool DeleteUser(Users deleteUser)
    {
        try
        {
            dbContext.Users.Remove(deleteUser);
            dbContext.SaveChanges();
            return true;
        }
        catch
        {
            return false;
        }
    }

    public int isAdmin(string email)
    {
        try
        {
            Users? admin = dbContext.Users.FirstOrDefault(user => user.UserEmail == email && user.UserId == 20);
            if(admin != null)
            {
                return 1;
            }
            return -1;
        }
        catch
        {
            return - 1;
        }
    }


    public List<Models.Users> GetAll()
    {
        return dbContext.Users.ToList();    
    }

    public bool IsUserExist(int userId)
    {
        return dbContext.Users.FirstOrDefault(u => u.UserId == userId) != null;
    }

    public bool IsUserUnderWarning(int userId)
    {
        try
        {
            var user = dbContext.UsersUnderWarning.Where(u => u.UserId == userId).FirstOrDefault();
            return user != null;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public string GetUserPassword(int id)
    {
        try
        {
            Users? matchUser = dbContext.Users.FirstOrDefault(user => user.UserId == id);
            if (matchUser != null)
            {
                return matchUser.UserPassword;
            }
            return "";
        }
        catch
        {
            return "";
        }
    }

    public string GetUserName(int id)
    {
        try
        {
            if(id == -2)
                return "UnknownUser";

            Models.Users? matchUser = (Users)dbContext.Users.FirstOrDefault(user=> user.UserId == id);
            Console.WriteLine("matchUser is: ", matchUser);
            if(matchUser != null)
                return matchUser.UserName;
            return "";
        }
        catch
        {
            return "";
        }
    }
}

