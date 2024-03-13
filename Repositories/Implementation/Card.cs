using Arch.EntityFrameworkCore;
using Repositories.Interfaces;
using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Repositories.Implementation;

public class Card : Interfaces.ICard
{
    private readonly Encryption _encryption;
    private readonly IDbContext dbContext;



    //public static string GenerateAESKey()
    //{
    //    using (Aes aes = Aes.Create())
    //    {
    //        aes.KeySize = 256;
    //        aes.GenerateKey();
    //        return Convert.ToBase64String(aes.Key);
    //    }
    //}


    private const string KEY = "hzRvAUpghiaRmuAFBP+J3VlvFKC5Vge5WEAIuol3S2Y=";

    public Card(IDbContext _dbContext)
    {
        dbContext = _dbContext;
        _encryption = new Encryption();
    }
    public Card()
    { 
        dbContext = new GmachimSaraAndShaniContext();
    }


    //Helping function that encrypt the exist data-למחוק אחרי שמצפינים פעם אחת
    public void EncryptDataBase()
    {
        try
        {
            var cards = dbContext.Card.ToList();
            cards.ForEach(c => EncryptDecryptCard(c, true));
            dbContext.SaveChanges();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }




    List<Models.Card> ICard.GetAllUserCards(int id)
    {
        try
        {
            List<Models.Card> allUSerCards = dbContext.Card.Where(card => card.UserId == id).ToList();
            
            if(allUSerCards.Count> 0)
            {
                
                return allUSerCards.Select(c => EncryptDecryptCard(c, false)).ToList();
            }
            return new List<Models.Card>();

        }
        catch
        {
            return new List<Models.Card>();

        }
    }

    public bool CheckIfUserHasCard(int UserId)
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
            dbContext.Card.Add(EncryptDecryptCard(card, false));
            dbContext.SaveChanges();
            return card.CardId;
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw new Exception("Catch an exception", ex);
        }
    }

    public List<Models.Card> GetAllCards()
    {
        try
        {
            return dbContext.Card.Select(c => EncryptDecryptCard(c, false)).ToList();
        }
        catch
        {
            return new List<Models.Card>();
        }
    }

    private Models.Card EncryptDecryptCard(Models.Card card, bool isEncrypt)
    {
        try
        {
            if (isEncrypt)
            {
                card.CreditCardNumber = Encryption.EncryptString(card.CreditCardNumber, KEY);
            }
            else
            {
                card.CreditCardNumber = Encryption.DecryptString(card.CreditCardNumber, KEY);
            }
            return card;
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw new Exception("Error with encription");
        }
    }



}
