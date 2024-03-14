using Microsoft.EntityFrameworkCore.Query.Internal;
using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Implementation;

public class Deposit : Interfaces.IDeposit
{
    private IDbContext dbContext;

    public Deposit(IDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public Deposit()
    {
        dbContext = new GmachimSaraAndShaniContext();
    }

    public IEnumerable<Repositories.Models.Deposit> AllUserDeposits(int userId)
    {
        try
        {
            return dbContext.Deposits.Where(deposit=> deposit.UserId == userId);

        }
        catch {
        return Enumerable.Empty<Repositories.Models.Deposit>();
        }
    }


    /// <summary>
    /// Add deposit to the data-base
    /// </summary>
    /// <param name="newDeposit">deposit details</param>
    /// <returns>depositId or -1, 0</returns>
    public int AddADeposit(Models.Deposit newDeposit)
    {
        try
        {
            dbContext.Deposits.Add(newDeposit);
            dbContext.SaveChanges();
            return newDeposit.DepositId;
        }
        catch
        {
            return -1;
        }
    }

    public IEnumerable<Models.Deposit> GetAll()
    {
        try
        {
            return dbContext.Deposits;
        }
        catch
        {
            return new List<Models.Deposit>();
        }
    }

    public List<Models.Deposit>? GetAllTheDepositsByDate(DateTime date)
    {
        try
        {
            return dbContext.Deposits.Where(d => d.DateToPull > date).ToList();
        }
        catch(Exception ex) 
        {
            Console.WriteLine(ex.Message);
            return null;
        }
    }

    public Models.Deposit Get(int depositId)
    {
        try
        {
            Models.Deposit? deposit = dbContext.Deposits.Where(l => l.DepositId == depositId).FirstOrDefault();
            if (deposit != null)
            {
                return deposit;
            }
            throw new ArgumentNullException("deposit");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw new Exception(ex.Message);
        }
    }

    public bool Update(Models.Deposit deposit)
    {
        try
        {
            dbContext.Deposits.Update(deposit);
            dbContext.SaveChanges();
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }
    }

    public int GetDepositCreditCardId(int depositId)
    {
        try
        {
            int? ans = dbContext.CardAndDeposit.Where(x => x.DepositId == depositId).Select(x => x.CardId).FirstOrDefault();
            return ans != null ? (int)ans : -1;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return -2;
        }
    }

    public bool SetCreditCardToDeposit(int depositId, int CreditCardId)
    {
        try
        {
            if (dbContext.CardAndDeposit.Where(x => x.DepositId == depositId ).Any())
                return false;

            dbContext.CardAndDeposit.Add(new CardAndDeposit() { DepositId = depositId, CardId = CreditCardId });
            dbContext.SaveChanges();
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }
    }

    public bool Return(int depositId)
    {
        try
        {
            dbContext.Deposits.Where(d => d.DepositId == depositId).FirstOrDefault().IsReturned = true;
            dbContext.SaveChanges();
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }
    }
}
