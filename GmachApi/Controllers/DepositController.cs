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

        // POST api/<DepositController>
        [HttpPut("AddADeposit")]
        public int AddDeposit([FromBody] Deposit newDeposit)
        {
            try
            {
                return deposit.AddADeposit(newDeposit);
            }
            catch(Exception ex)
            {
                return 1;

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
