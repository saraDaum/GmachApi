using DTO.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GmachApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepositorController : ControllerBase
    {


        // GET: api/<DepositorController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }


        // GET api/<DepositorController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<DepositorController>
        [HttpPost("AddNewDepositor/{id}")]
        public ActionResult<List<DTO.Models.Deposit>> AddNewDepositor([FromBody] int userId)
        {

            return BadRequest();
        }

        // PUT api/<DepositorController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DepositorController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        
        
    }
}
