using DTO.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GmachApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardController : ControllerBase
    {
        Services.IServices.ICard Card = new Services.Implemantation.Card();

        // GET: api/<AcountController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<CardController>/5
        [HttpGet("GetAllCards/{id}")]
        public List<Card> GetAllCards([FromRoute]int id)
        {
            try
            {
                return Card.GetAllCards(id);
            }
            catch (Exception ex)
            {
                return new List<Card>();
            }
        }

        // POST api/<AcountController>
        [HttpPost("AddNewCard")]
        public ActionResult<int> AddNewCard([FromBody] Card card)
        {
            try
            {
                int response = Card.AddNewCard(card);
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
        [HttpGet("IsCardExistByUserId")]
        public bool IsCardExistByUserId(int UserId)
        {
            try
            {
                return Card.IsCardExistByUserId(UserId);
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
