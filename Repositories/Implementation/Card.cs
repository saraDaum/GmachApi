using Repositories.Interfaces;
using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Implementation;

public class Card : Interfaces.ICard
{

    private readonly IDbContext dbContext;
    public Card(IDbContext _dbContext)
    {
        dbContext = _dbContext;
    }
    public Card()
    { 
        dbContext = new GmachimSaraAndShaniContext();
    }




  

    List<Models.Card> ICard.GetAllUserCards(int id)
    {
        try
        {
            List<Models.Card> allUSerCards = dbContext.Card.Where(card=> card.UserId == id).ToList();   
            if(allUSerCards.Count> 0)
            {
                return allUSerCards;
            }
            return new List<Models.Card>();

        }
        catch
        {
            return new List<Models.Card>();

        }
    }

    public bool checkIfUserHasCard(int UserId)
    {
        try
        {
            return dbContext.Card.Any(card => card.UserId == UserId);
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw new Exception("We catch an exception", ex);
        }
    }

    public int AddNewCard(Models.Card card)
    {
        try
        {
            dbContext.Card.Add(card);
            dbContext.SaveChanges();
            return card.CardId;
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw new Exception("Catch an exception", ex);
        }
    }


}
