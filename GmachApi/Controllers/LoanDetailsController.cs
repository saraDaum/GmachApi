using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
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
        public List<Loan> GetUserLoans(int id)
        {
            return loanDetail.GetUserLoans(id);
        }

        //GET api/<LoansDetailController>
        /// <summary>
        /// This function returns all loans.
        /// The loans requests and approvaled loans.
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAll")]
        public List<Loan> GetAll() {
            try {
                return loanDetail.GetAllLoans();
            }
            catch {
                return new List<Loan>();
            }
        }

        [HttpGet("GetAllDetails")]
        public List<LoanDetails> GetAllDetails()
        {
            try
            {
                return loanDetail.GetAllLoansDetails();
            }
            catch
            {
                return new List<LoanDetails>();
            }
        }

        /// <summary>
        /// This function returns all approval loans
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllApprovaledLoans")]
        public List<Loan> GetAllApprovalLoans()
        {
            try
            {
                List<Loan> allLoans = GetAll();
                List<Loan> approvedLoans = allLoans.Where(loan => loan.IsAprovied).ToList();
                return approvedLoans;
            }
            catch
            {
                return new List<Loan>();
            }
        }

        /// <summary>
        /// This function returns all loan requests.
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllNotApprovaledLoans")]
        public List<LoanDetails> GetAllNotApprovalLoans()
        {
            try
            {
                List<LoanDetails> allLoans = GetAllDetails();
                List<LoanDetails> notApprovedLoans = allLoans.Where(loan => loan.IsAprovied==false).ToList();
                return notApprovedLoans;
            }
            catch
            {
                return new List<LoanDetails>();
            }
        }

        // POST api/<AddNewLoan>
        [HttpPost("AddNewLoan")]
        public ActionResult<int> AddNewLoan([FromBody] DTO.Models.LoanDetails loan)
        {
            try
            {
                Loan l = new Loan(loan.LoanId, loan.LoanerId, loan.DateToGetBack, loan.Sum, loan.LoanFile, false);
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
        public bool Delete(int id)
        {
            try
            {
                return loanDetail.Delete(id); 
            }
            catch
            {
                return false;
            }
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
                    var ans = loanDetail.GetLoansToApproval();
                    Console.WriteLine(ans);
                    return ans;
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
