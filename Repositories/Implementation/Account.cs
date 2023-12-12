using Repositories.Interfaces;
using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Implementation;

public class Account : Interfaces.IAccount
{

    private IDbContext dbContext;

    public Account(IDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public Account()
    { 
        dbContext = new GmachimSaraAndShaniContext();
    }




    public bool checkIfUserHasAccount(int UserId)
    {
        try
        {
            // Check if any account with the specified UserId exists
            bool accountExists = dbContext.Accounts.Any(a => a.UserId == UserId);

            // Return the result
            return accountExists;
        }
        catch (Exception ex)
        {
            // Handle exceptions if needed
            Console.WriteLine($"Error checking account existence: {ex.Message}");
            return false; // or throw an exception based on your error handling strategy
        }
    }

    public int AddNewAccount(Models.Account account)
    {
        try
        {
            dbContext.Accounts.Add(account);
            dbContext.SaveChanges();
            return account.AccontId;
        }
        catch (Exception ex)
        {
            // Handle exceptions if needed
            Console.WriteLine($"Error checking account existence: {ex.Message}");
            return -1; // or throw an exception based on your error handling strategy
        }
    }

    List<Models.Account> IAccount.GetAllUserCards(int id)
    {
        try
        {
            List<Models.Account> allUSerCards = dbContext.Accounts.Where(card=> card.UserId == id).ToList();   
            if(allUSerCards.Count> 0)
            {
                return allUSerCards;
            }
            return new List<Models.Account>();

        }
        catch
        {
            return new List<Models.Account>();

        }
    }

    bool IAccount.checkIfUserHasAccount(int UserId)
    {
        throw new NotImplementedException();
    }

    int IAccount.AddNewAccount(Models.Account account)
    {
        throw new NotImplementedException();
    }


}
