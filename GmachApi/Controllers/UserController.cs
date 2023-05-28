using Azure;
using Microsoft.AspNetCore.Mvc;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GmachApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
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

      /* 
       * axios.get('https://api.example.com/data')
       * .then(response => console.log(response.data))
       * .catch(error => console.error(error));
      */

        // POST api/<sign in>
        [HttpPost("SignIn")]
        public void SignIn([FromBody] DTO.Models.User newUser)
        {
        }
        

        // POST api/<log in>
        [HttpPost("LogIn")]
        public void LogIn([FromBody] DTO.Models.User  loginUser)
        {
            
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
}
