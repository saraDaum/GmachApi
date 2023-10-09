using DTO.Models;
using Microsoft.AspNetCore.Mvc;
using Repositories.Interfaces;using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GmachApi.Controllers;

[Route("api/[controller]")]
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
    [HttpPost("SignIn")]
    public int SignIn([FromBody] User newUser)
    {
        
        if (!userService.IsUserExists(newUser))
            return userService.SignIn(newUser);
        else
            return -1;
    }

    // POST api/<log in>
    [HttpPost("LogIn")]
    public ActionResult < DTO.Models.LoginUser > LogIn([FromBody] LoginUser loginUser)
    {
        //return "Connected!!";
        return new LoginUser();
        return NotFound ();
        
        
    }

    // PUT api/<UserController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/<UserController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}
