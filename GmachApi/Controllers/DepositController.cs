using DTO.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GmachApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepositController : ControllerBase
    {

        internal Services.IServices.IDeposit deposit = new Services.Implemantation.Deposit();

        // GET: api/<DepositController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<DepositController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpGet("/GetAll")]
        public IEnumerable<Deposit> AllDeposits()
        {
            return new List<Deposit>();
        }

        [HttpGet("AllUserDeposits/{id}")]
        public IEnumerable<Deposit> GetUserDeposits([FromRoute]int id)
        {
            try
            {
                return deposit.AllUserDeposits(id);
            }
            catch{ 
                return new List<Deposit>();
            }
        }


        /// <summary>
        /// Add a new deposit
        /// </summary>
        /// <param name="newDeposit">deposit details</param>
        /// <returns>the deposit id, or error</returns>
        // POST api/<DepositController>
        [HttpPost("AddADeposit")]
        public ActionResult<int> AddDeposit([FromBody] Deposit newDeposit)
        {
            try
            {

                int response = deposit.AddADeposit(newDeposit);
                if (response == -3) // When user doesn't have a bank account in the system.
                {
                  return BadRequest("User does not have a bank account yet!");
                    
                }
                if(response == -2) //in case that the provided userId is not an id of any user.
                {
                    return BadRequest("user not exist");
                }
                if(response == -1) //in case it an add to data-base error. 
                {
                    return BadRequest("Error in the server");
                }
                return response; //the deposit Id
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);

            }
            
        }

        // PUT api/<DepositController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DepositController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
