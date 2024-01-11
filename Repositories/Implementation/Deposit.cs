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
    /// <returns>1 or -1, 0</returns>
    public int AddADeposit(Models.Deposit newDeposit)
    {
        try
        {
            dbContext.Deposits.Add(newDeposit); 
            return dbContext.SaveChanges();
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
}
