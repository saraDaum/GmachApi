﻿using DTO.Models;
using Microsoft.AspNetCore.Mvc;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace GmachApi.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        Services.IServices.IUser userService;
        internal Services.IServices.IUser user = new Services.Implemantation.User();

        //public UserController(Services.IServices.IUser _userService)
        //{
        //    userService = _userService;
        //}

        
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
        //[Route("api/User/SignIn"), HttpPost]
        [HttpPost("SignIn")]
        public int SignIn([FromBody] User newUser)

        {
            //return 100;
            //Console.WriteLine(newUser.UserName);
            LoginUser checkUser = new LoginUser { UserName = newUser.UserName, Password = newUser.UserPassword };
            if (!userService.IsUserExists(checkUser)) //Returns true if user already exist
              return userService.SignIn(newUser);
            else
                return -1;
        }

        // POST api/<log in>
        [HttpPost("LogIn")]
        public ActionResult<DTO.Models.LoginUser> LogIn([FromBody] LoginUser loginUser)
        {
            Console.WriteLine(loginUser);

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
}