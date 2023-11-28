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
    public List<Models.LoanDetails> GetLoanDetails(int userId)
    {
        try
        {

            if ((Models.LoanDetails)dbContext.LoanDetails.Where(loan => loan.UserId == userId) == null)
            {
                return new List<Models.LoanDetails>();
            }
            else return dbContext.LoanDetails.Where(loan => loan.UserId!= userId).ToList();
            
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
