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

    private readonly IDbContext dbContext;

    public Account(IDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public Account()
    { 
        dbContext = new GmachimSaraAndShaniContext();
    }



    /// <summary>
    /// Gets user id and return a bollean value if user has a bank account in system or not.
    /// </summary>
    /// <param name="UserId"></param>
    /// <returns></returns>
    public bool checkIfUserHasAccount(int UserId)
    {
        try
        {
            // Check if any account with the specified UserId exists
            bool accountExists = dbContext.Cards.Any(a => a.UserId == UserId);

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
    /// <summary>
    /// Addes a new user bank account to database.
    /// Gets a bank account entity and return the AccountId.
    /// </summary>
    /// <param name="account"></param>
    /// <returns></returns>
    public int AddNewAccount(Models.Account account)
    {
        try
        {
            dbContext.Accounts.Add(account);
            dbContext.SaveChanges();
            return account.Id;
        }
        catch (Exception ex)
        {
            // Handle exceptions if needed
            Console.WriteLine($"Error checking account existence: {ex.Message}");
            return -1; // or throw an exception based on your error handling strategy
        }
    }

    public List<Models.Account> GetAllAccounts()
    {
        try
        {
            List<Models.Account> allAccounts =  dbContext.Accounts.ToList();
            return allAccounts;
        }
        catch (Exception ex)
        {
            return new List<Models.Account>();
        }
    }

    bool IAccount.checkIfUserHasAccount(int UserId)
    {
        throw new NotImplementedException();
    }

    


}
