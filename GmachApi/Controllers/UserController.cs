using DTO.Models;
using Microsoft.AspNetCore.Mvc;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace GmachApi.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        //Services.IServices.IUser userService;
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
            Console.WriteLine(newUser.UserName);
            LoginUser checkUser = new LoginUser { UserName = newUser.UserName, UserPassword = newUser.UserPassword };
            if (!user.IsUserExists(checkUser)) //Returns true if user already exist
                 return user.SignIn(newUser);
            return 0;
               
        }

        // POST api/<log in>
        [HttpPost("LogIn")]
        public ActionResult<DTO.Models.UserInfo> LogIn([FromBody] LoginUser loginUser)
        {
            DTO.Models.UserInfo? userInfo = user.Login(loginUser);
            if (userInfo != null) { return NotFound(); }
            Console.WriteLine(loginUser);

            //return new LoginUser { UserName = "Connected", UserPassword = "00" }; //To get this message.Sara.
            //return new LoginUser();
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