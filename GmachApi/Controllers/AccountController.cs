using DTO.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=39786
namespace GmachApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    Services.IServices.IAccount Account = new Services.Implemantation.Account();

    // GET api/<AcountController>/5
    [HttpGet("GetAllAcconts")]
    public List<Account> GetAllAccounts()
    {
        try
        {
            return Account.GetAllAccounts();
        }
        catch
        {
            return new List<Account>();
        }
    }

    // POST api/<AcountController>
    [HttpPost("AddNewAccount")]
    public ActionResult<int> AddNewAccount([FromBody] Account account)
    {
        try
        {
            int response = Account.AddNewAccount(account);
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


    // GET api/<AcountController>/5
    [HttpGet("IsAccountExistByUserId")]
    public bool IsAccountExistByUserId(int UserId)
    {
        try
        {
            return Account.IsAccountExistByUserId(UserId);
        }
        catch (Exception ex)
        {
            // Handle exceptions if needed
            Console.WriteLine($"Error checking account existence: {ex.Message}");
            return false; // or throw an exception based on your error handling strategy
        }
    }
}
