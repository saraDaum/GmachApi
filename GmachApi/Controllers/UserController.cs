using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GmachApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    internal Services.IServices.IUser user = new Services.Implemantation.User();
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
    public void SignIn([FromBody] string value)
    {
    }

    // POST api/<log in>
    [HttpPost("LogIn")]
    public void LogIn([FromBody] string value)
    {
        //split the value to name and password
        string name;
        string password;
        user.Login(name, password);
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
