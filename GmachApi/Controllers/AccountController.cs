using DTO.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GmachApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        Services.IServices.IAccount Account = new Services.Implemantation.Account();

        // GET: api/<AcountController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<AcountController>/5
        [HttpGet("GetAllCards/{id}")]
        public List<DTO.Models.Account> GetAllCards([FromRoute]int id)
        {
            try
            {
                return Account.GetAllCards(id);
            }
            catch (Exception ex)
            {
                return new List<DTO.Models.Account>();
            }
        }

        // POST api/<AcountController>
        [HttpPost("AddNewAccount")]
        public ActionResult<int> AddNewAccount([FromBody] Account account)
        {
            try
            {
                int response = Account.AddNewAccount(account);
                if (response == -3)
                {
                    return BadRequest("User not exist");
                }
                if(response == -2)
                {
                    return BadRequest("User Already has a bank Account.");
                }
                if(response == -1)
                {
                    return BadRequest("Error in the server");
                }
                return response;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<AcountController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AcountController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        // GET api/<AcountController>/5
        [HttpGet("IsAccountExistByUserId")]
        public bool IsAccountExistByUserId(int UserId)
        {
            try
            {
                return Account.IsAccountExistByUserId(UserId);
            }
            catch (Exception ex)
            {
                // Handle exceptions if needed
                Console.WriteLine($"Error checking account existence: {ex.Message}");
                return false; // or throw an exception based on your error handling strategy
            }
        }
    }
}
