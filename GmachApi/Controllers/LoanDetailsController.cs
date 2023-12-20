using DTO.Models;
using Microsoft.AspNetCore.DataProtection;
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
                DTO.Models.Loan l = new DTO.Models.Loan(loan.LoanId, loan.UserId, loan.DateToGetBack, loan.Sum, loan.LoanFile, false);
                int res = loanDetail.AddLoan(l, loan.guarantors);
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


        /// <summary>
        /// When the admin decided to approve a loan
        /// </summary>
        /// <param name="loanID">the id of the loan</param>
        /// <param name="confirmation">a string to ensure is the admin</param>
        /// <returns>success</returns>
        [HttpPost("LoanApproval")]
        public bool LoanApproval([FromBody] int loanID, [FromHeader]string confirmation)
        {
            try
            {
                if (confirmation == "15987532")
                {
                    return loanDetail.LoanApproval(loanID);
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }


        }


        /// <summary>
        /// Controller that give the admin list of loans that he should approve.
        /// </summary>
        /// <param name="confirmation">identetiy of admin</param>
        /// <returns>the loan list</returns>
        [HttpPost("AdminGetLoanForApproval")]
        public IEnumerable<int>? AdminGetLoanForApproval([FromHeader] string confirmation)
        {
            try
            {
                if(confirmation == "15987532")
                {
                    return loanDetail.GetLoansToApproval();
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
