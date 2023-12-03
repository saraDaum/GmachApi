using Microsoft.EntityFrameworkCore.Query.Internal;
using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Repositories.Implementation;

public class LoanDetails : Interfaces.ILoanDetails
{

    private readonly IDbContext dbContext;

    //Constructors
    public LoanDetails(IDbContext ctx)
    {
        dbContext = ctx;
    }
    public LoanDetails()
    {
        dbContext = new GmachimSaraAndShaniContext();
    }

    public int AddLoan(Models.LoanDetails loansDetail)
    {
        //todo: add to the data base the loan object

        return 133;
    }
    public List<Models.LoanDetails> GetUserLoans (int userId)
    {
        try
        {
            IEnumerable<Models.LoanDetails> allUserLoans = (IEnumerable<Models.LoanDetails>)dbContext.LoanDetails.Where(loan=> loan.UserId == userId);
            List<Models.LoanDetails> AllUserLoans = allUserLoans.ToList();
            if (AllUserLoans.Count == 0)
            {
                return new List<Models.LoanDetails>();
            }
            else return AllUserLoans;
            
        }
        catch
        {
            return new List< Models.LoanDetails>();    
        }
    }

   public List<Models.LoanDetails> GeAlltLoans()
    {
        return dbContext.LoanDetails.ToList();
    }
}
