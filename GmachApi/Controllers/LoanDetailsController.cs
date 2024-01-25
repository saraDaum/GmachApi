using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using DTO.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GmachApi.Controllers;


[Route("api/[controller]")]
[ApiController]
public class LoanDetailsController : ControllerBase
{
    internal Services.IServices.ILoanDetails loanDetail = new Services.Implemantation.LoanDetails();
    

    // GET api/<LoansDetailController>/GetUserLoans/userId
    [HttpGet("GetUserLoans/{id}")]
    public List<Loan> GetUserLoans(int id)
    {
        try
        {
            return loanDetail.GetUserLoans(id) ?? new List<Loan>();
        }
        catch (Exception ex)
        {
            return new List<Loan>();
        }
        
    }

    //GET api/<LoansDetailController>
    /// <summary>
    /// This function returns all loans.
    /// The loans requests and approvaled loans.
    /// </summary>
    /// <returns></returns>
    [HttpGet("GetAll")]
    [Authorize(Policy = "AdminOnly")]
    public List<Loan> GetAll() {
        try 
        {
            return loanDetail.GetAllLoans();
        }
        catch 
        {
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
    [Authorize(Policy = "AdminOnly")]
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
    [Authorize(Policy = "AdminOnly")]
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

    //TODO: We need to implement it
    [HttpPost("Return/{id}")]
    public bool Return(int loanId)
    {
        try
        {
            return true;
        }
        catch
        {
            return false;
        }
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
    [Authorize(Policy = "AdminOnly")]
    public bool LoanApproval([FromBody] int loanID)
    {
        try
        {
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
    [Authorize(Policy = "AdminOnly")]
    public IEnumerable<int>? AdminGetLoanForApproval()
    {
        try
        {
            var ans = loanDetail.GetLoansToApproval();
            Console.WriteLine(ans);
            return ans;
        }
        catch (Exception ex)
        {
            return null;
        }
    }


    [HttpGet("ReportALoan")]
    [Authorize(Policy = "AdminOnly")]
    public bool ReportALoan(int id, bool safe)
    {
        try
        {
            return loanDetail.ReportALoan(id, safe);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return false; 
        }

    }

    

}
