using DTO.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using System.Xml.Linq;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace GmachApi.Controllers;


[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{


    internal Services.IServices.IUser _user = new Services.Implemantation.User();


    // POST api/<SignIn>
    /// <summary>
    ///This function gets a new user and check if a user with these details
    /// already exist in database before register him.
    /// </summary>
    /// <param name="newUser"></param>
    /// <returns></returns>
    [HttpPost("SignIn")]
    public int SignIn([FromBody] User newUser)
    {//  ActionResult<DTO.Models.UserInfo>
        try
        {
            return (_user.SignIn(newUser));
        }
        catch
        {
            return -1;
        }
    }



    // POST api/<LogIn>
    /// <summary>
    /// Login controller, check if the user exist in the system, by user name and password.
    /// </summary>
    /// <param name="loginUser">user name and password</param>
    /// <returns>user info, or user not found</returns>
    [HttpPost("LogIn")]
    public ActionResult<DTO.Models.UserInfo> LogIn([FromBody] LoginUser loginUser)
    {
        try
        {
            DTO.Models.UserInfo? userInfo = _user.Login(loginUser);
            if (userInfo == null) { return NotFound(); }
            Console.WriteLine(loginUser);
            return userInfo;
        }
        catch (Exception)
        {
            return BadRequest("Error in the server");
        }
    }

    [HttpPost("Admin/LogIn")]
    public bool AdminLogIn([FromRoute] string email, [FromRoute] string password)
    {
        try
        {
            LoginUser isAdmin = new LoginUser(email, password);
            return _user.AdminLogIn(isAdmin);
        }
        catch
        {
            return false;
        }
    }

    [HttpGet("GetAllUsers")]
    public List<User> GetUsers()
    {
        return _user.GetAllUsers();
    }

    [HttpGet("GetUser/{id}")]
    public User? GetUser([FromRoute] int id)
    {
        try
        {
            bool exist = _user.IsUserExist(id);//Use IsUserExist() function to save unnecessary access to the database.
            if (exist)
            {
                User user = _user.GetUser(id);
                return user;
            }
            else
            {
                return null;
            }
        }
        catch
        {
            return null;
        }
    }

    [HttpDelete("{id}")]
    public bool DeleteUser([FromBody] int id)
    {
        return _user.DeleteUser(id);
        return false;
    }
}