using DTO.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace GmachApi.Controllers;


[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{


    internal Services.IServices.IUser user = new Services.Implemantation.User();


    // POST api/<SignIn>
    /// <summary>
    ///This function gets a new user and check if a user with these details
    /// already exist in database before register him.
    /// </summary>
    /// <param name="newUser"></param>
    /// <returns></returns>
    [HttpPost("SignIn")]
    public ActionResult<DTO.Models.UserInfo> SignIn([FromBody] User newUser)
    {
        try
        {
            int ans = user.SignIn(newUser);
            if (ans == -1) { return BadRequest("couldn't add the user to the database"); }
            if (ans == -2) { return BadRequest("user already exist"); }
            return new UserInfo
            {
                UserNumber = ans,
                UserName = newUser.UserName,
                UserEmail = newUser.UserEmail,
                UserAddress = newUser.UserAddress,
                UserPhone = newUser.UserPhone
            };

        }
        catch
        {
            return BadRequest("error while singing in");
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
            DTO.Models.UserInfo? userInfo = user.Login(loginUser);
            if (userInfo == null) { return NotFound(); }
            Console.WriteLine(loginUser);
            return userInfo;
        }
        catch (Exception)
        {
            return BadRequest("Error in the server");
        }


    }
}