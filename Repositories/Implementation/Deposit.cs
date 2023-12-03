using Microsoft.EntityFrameworkCore.Query.Internal;
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
       /**
        * 
        Sum = 0;
        DateToPull = DateTime.Now;
        UserId = -1;
        DepositId = -1;*/
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
}
