using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GmachApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuarantorController : ControllerBase
    {
        // GET: api/<GuarantorController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<GuarantorController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<GuarantorController>
        [HttpPost]
        public void Post([FromBody] string value)
        {

        }

        // PUT api/<GuarantorController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<GuarantorController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
