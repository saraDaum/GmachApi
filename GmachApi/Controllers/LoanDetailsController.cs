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

        // GET api/<LoansDetailController>/GetUserLoans/userId
        [HttpGet("GetUserLoans/{id}")]
        public List<LoanDetails> GetUserLoans(int id)
        {
            return loanDetail.GetUserLoans(id);
        }

        //GET api/<LoansDetailController>
        [HttpGet("GetAll")]
        public List<LoanDetails> GetAll() {
            return loanDetail.GetAllLoans();
        }

        // POST api/<LoansDetailController>
        [HttpPost("AddNewLoan")]
        public ActionResult<int> AddNewLoan([FromBody] DTO.Models.LoanDetails loan)
        {
            try
            {
                int res = loanDetail.AddLoan(loan);
                if (res < 0)
                {
                    return BadRequest(res);
                }

                return res;
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
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
