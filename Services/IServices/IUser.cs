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

    /// <summary>
    /// Gets a User entity and addes it to database.
    /// </summary>
    /// <param name="newUser"></param>
    /// <returns></returns>
    public int SignIn(User newUser);

    /// <summary>
    /// Gets a UserLogin entity and returns true if user is existing in database and false, if not.
    /// </summary>
    /// <param name="newUser"></param>
    /// <returns></returns>
    bool IsUserExists(LoginUser newUser);

    /// <summary>
    /// Retuens all users that in database.
    /// </summary>
    /// <returns></returns>
    List<User> GetAllUsers();

    /// <summary>
    /// Gets a user id and returns true if user is existing in database and false, if not.
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    bool IsUserExist(int  userId);

    /// <summary>
    /// Gets a user id and delete the match user entity.
    /// Returns true if deletion was successful or false, if not.
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    bool DeleteUser(int userId);

    bool AdminLogIn(LoginUser isAdmin);

    /// <summary>
    /// Gets a user id and returns the match user entity.
    /// </summary>
    /// <param name="UserId"></param>
    /// <returns></returns>
    User? GetUser(int UserId);

    /// <summary>
    /// Gets a user id and returns his password.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    string GetUserPassword(int id);

    /// <summary>
    /// This function gets user id and returns his name.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    string GetUserName(int id);

    /// <summary>
    /// This function gets user id and returns his email address.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    string GetUserEmail(int id);
}
