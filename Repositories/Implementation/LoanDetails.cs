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
        try
        {
            dbContext.LoanDetails.Add(loansDetail);
            dbContext.SaveChanges();

            return loansDetail.LoanId;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return -2;
        }
    }

    public bool IsLoanExist(int loanId)
    {
        try
        {
            return dbContext.LoanDetails.FirstOrDefault(l => l.LoanId == loanId) != null;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return false;
        }
    }

    public bool LoanApproval(int loanID)
    {
        try
        {
            Models.LoanDetails? l = dbContext.LoanDetails.Where(l => l.LoanId == loanID).FirstOrDefault();
            if (l == null)
                return false;
            l.IsAprovied = true;
            dbContext.SaveChanges();
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return false;
        }
    }


    public List<Models.LoanDetails>? GetWaitingList()
    {
        try
        {
            return dbContext.LoanDetails.Where(l => !l.IsAprovied).ToList();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            throw new Exception("Error: catch an ecxeption in GetWaitingList function", ex);
        }
    }

    public List<Models.LoanDetails>? getLoans(Func<Models.LoanDetails, bool>? predicate = null)
    {
        if (predicate == null) 
            return dbContext.LoanDetails.ToList();
        else
            return dbContext.LoanDetails.Where(predicate).ToList();
    }

}
