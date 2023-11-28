using DTO.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GmachApi.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class LoanDetailsController : ControllerBase
    {
        internal Services.IServices.ILoanDetails loanDetail = new Services.Implemantation.LoanDetails();
        // GET: api/<LoansDetailController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<LoansDetailController>/5
        [HttpGet("{id}")]
        public List<LoanDetails> Get(int id)
        {
            return loanDetail.GetLoan(id);
        }

        //GET api/<LoansDetailController>
        [HttpGet("GetAll")]
        public List<LoanDetails> GetAll() {
            return loanDetail.GetAllLoans();
        }

        // POST api/<LoansDetailController>
        [HttpPost]
        public int Post([FromBody] DTO.Models.LoanDetails loan)
        {
            return loanDetail.AddLoan(loan);
        }

        // PUT api/<LoansDetailController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LoansDetailController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
