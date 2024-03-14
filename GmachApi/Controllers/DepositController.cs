using DTO.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GmachApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DepositController : ControllerBase
{

    internal Services.IServices.IDeposit deposit = new Services.Implemantation.Deposit();

    /// <summary>
    /// Returns all deposits in database, returned and not.
    /// </summary>
    /// <returns></returns>
    [HttpGet("GetAll")]
    [Authorize(Policy = "AdminOnly")]
    public List<Deposit> AllDeposits()
    {
        try
        {
            return deposit.GetAll();
        }
        catch
        {
            return new List<Deposit>();
        }
    }


    /// <summary>
    /// Returns all deposits that not returned yet.
    /// </summary>
    /// <returns></returns>
    [HttpGet("GetAllDepositsNotReturned")]
    [Authorize(Policy = "AdminOnly")]
    public List<Deposit> GetNotReturnedDeposits() {
        try
        {
            return deposit.GetNotReturnedDeposits();
        }
        catch
        {
            return new List<Deposit>();
        }
    }

    /// <summary>
    /// Returns all deposits that already returned.
    /// </summary>
    /// <returns></returns>
    [HttpGet("GetAllDepositsAlreadyReturned")]
    [Authorize(Policy = "AdminOnly")]
    public List<Deposit> GetReturnedDeposits()
    {
        try
        {
            return deposit.GetReturnedDeposits();
        }
        catch
        {
            return new List<Deposit>();
        }
    }

    /// <summary>
    /// Returns all user deposits.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
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
    public int AddDeposit([FromBody] Deposit newDeposit)
    {
        try
        {

            return deposit.AddADeposit(newDeposit);
            //I didn't delete it yet because I want to see what each response say. Sara.
            /*if response == -3 ::  When user doesn't have a bank account in the system.
            
            if   response == -2  :: in case that the provided userId is not an id of any user.
            
            if   response == -1  :: in case it an add to data-base error. */
           
        }
        catch
        {
            return -1;

        }
        
    }


    /// <summary>
    /// This function update deposit after it returned.
    /// </summary>
    /// <param name="depositId"></param>
    /// <returns></returns>
    [HttpPost("Return/{id}")]
    public bool Return([FromRoute]int id)
    {
        try
        {
            return deposit.Return(id);
        }
        catch
        {
            return false;
        }
    }


    [HttpGet("AddTimeToDeposit")]
    public bool AddTimeToDeposit(int depositId, DateTime newReturningDay)
    {
        try
        {
            return deposit.AddTimeToDeposit(depositId, newReturningDay);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false; 
        }
    }

}
