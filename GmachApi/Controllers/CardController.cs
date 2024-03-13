using DTO.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GmachApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CardController : ControllerBase
{
    Services.IServices.ICard Card = new Services.Implemantation.Card();

    // GET api/<CardController>/5
    [HttpGet("GetAllCards/{id}")]
    public List<Card> GetAllCards([FromRoute]int id)
    {
        try
        {
            return Card.GetAllCards(id);
        }
        catch 
        {
            return new List<Card>();
        }
    }


    [HttpGet("GetAllCards")]
  //  [Authorize(Policy = "AdminOnly")]
    public List<Card> GetAllCards()
    {
        try
        {
            return Card.GetAllCards();
        }
        catch
        {
            return new List<Card>();
        }
    }

    // POST api/<AcountController>
    [HttpPost("AddNewCard")]
    public int AddNewCard([FromBody] Card card)
    {
        try
        {
            return Card.AddNewCard(card);

                    }
        catch (Exception ex)
        {
            return -1;
            //return BadRequest(ex.Message);
        }
    }

    
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




    [HttpGet("EncryptDataBase")]
    public void EncryptDataBase()
    {
        try
        {
            Card.EncryptDataBase();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
