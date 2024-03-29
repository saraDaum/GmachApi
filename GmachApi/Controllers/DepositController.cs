﻿using DTO.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GmachApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DepositController : ControllerBase
{

    internal Services.IServices.IDeposit deposit = new Services.Implemantation.Deposit();

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
            /*if (response == -3) // When user doesn't have a bank account in the system.
            {
              return BadRequest("User does not have a bank account yet!");
                
            }
            if(response == -2) //in case that the provided userId is not an id of any user.
            {
                return BadRequest("user not exist");
            }
            if(response == -1) //in case it an add to data-base error. 
            {
                return BadRequest("Error in the server");
            }
            return response; //the deposit Id*/
        }
        catch
        {
            return -1;

        }
        
    }


    [HttpGet("Return/{depositId}")]
    [Authorize(Policy = "AdminOnly")]
    public bool Return([FromRoute] int depositId)
    {
        try
        {
            return deposit.Return(depositId);
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
