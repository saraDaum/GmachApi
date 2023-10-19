using Azure.Identity;
using DTO.Models;
using Microsoft.AspNetCore.Mvc;
using Repositories.Interfaces;
using System;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using FromBodyAttribute = Microsoft.AspNetCore.Mvc.FromBodyAttribute;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GmachApi.Controllers;

//[EnableCors("*", "*", "*")]//Hila added.
//[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    Services.IServices.IUser userService;
    public UserController(Services.IServices.IUser _userService)
    {
        userService = _userService;

    }
    //Services.IServices.IUser user = new Services.Implemantation.User();
    // GET: api/<UserController>
    [HttpGet("GetUserDetail")]
    public IEnumerable<string> GetUserDetail()
    {
        return new string[] { "value1", "value2" };
    }

    // GET api/<UserController>/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
        return "value";
    }

    // POST api/<sign in>
    /// <summary>
    ///This function gets a new user and check if a user with these details
    /// already exist in database before register him.
    /// </summary>
    /// <param name="newUser"></param>
    /// <returns></returns>
    [Route("api/User/SignIn"),HttpPost]
    public int SignIn([FromBody] User newUser)
    {

        LoginUser checkUser = new LoginUser { UserName = newUser.UserPassword, Password = newUser.UserPassword };
        if (!userService.IsUserExists(newUser))
            return userService.SignIn(newUser);
        else
            return -1;
    }

    // POST api/<log in>
    [HttpPost("LogIn")]
    public ActionResult<DTO.Models.LoginUser> LogIn([FromBody] LoginUser loginUser)
    {

        return new LoginUser { UserName = "Connected", Password = "00" }; //To get this message.Sara.
        return new LoginUser();
        return NotFound();


    }

    // PUT api/<UserController>/5
    //[HttpPut("{id}")]
    //public void Put(int id, [FromBody] string value)
    //{
    //    //What this function does?? Sara.
    //}

    // DELETE api/<UserController>/5
    //[HttpDelete("{id}")]
    //public void Delete(int id)
    //{

    //}
}
