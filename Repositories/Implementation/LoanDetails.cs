using Microsoft.EntityFrameworkCore.Metadata.Internal;
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

    /// <summary>
    /// Returns all loans in database.
    /// </summary>
    /// <param name="predicate"></param>
    /// <returns></returns>
    public List<Models.LoanDetails>? getLoans(Func<Models.LoanDetails, bool>? predicate = null)
    {
        if (predicate == null) 
            return dbContext.LoanDetails.ToList();
        else
            return dbContext.LoanDetails.Where(predicate).ToList();
    }

    /// <summary>
    /// Gets loan id, check if there is a loan with this LloanId.
    /// If yes- delete it and return true, if not- return false.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public bool Delete(int id)
    {
        try
        {
            Models.LoanDetails? matchLoanDetails = dbContext.LoanDetails.FirstOrDefault(loanDetails => loanDetails.LoanId == id);
            if (matchLoanDetails != null)
            {
                dbContext.LoanDetails.Remove(matchLoanDetails);
                dbContext.SaveChanges();
                return true;
            }
            return false;
        }
        catch
        {
            return false;
        }
    }


    /// <summary>
    /// Returns all investments that are redeemed before the given date.
    /// </summary>
    /// <param name="date"></param>
    /// <returns></returns>
    public int GetDepositsSumByDate(DateTime date)
    {       
        var deposits = dbContext.Deposits.Where(d => d.DateToPull < date);
        int sumOfAllDeposits = 0;
        foreach (var deposit in deposits)
        {
            sumOfAllDeposits += deposit.Sum;
        }
        return sumOfAllDeposits;
    }

    public bool Update(Models.LoanDetails loanDetails)
    {
        try
        {
            dbContext.LoanDetails.Update(loanDetails);
            dbContext.SaveChanges();
            return true;
        }
        catch(Exception ex) 
        {
            Console.WriteLine(ex.Message);
            return false; 
        }
    }

    public bool SetAccountToLoan(int loanId, int accountId)
    {
        try
        {
            // If the loan already asociate wuth an account
            if (dbContext.AccountAndLoans.Where(a => a.LoanId == loanId).Any())
                return false;

            dbContext.AccountAndLoans.Add(new AccountAndLoans()
            {
                LoanId = loanId,
                AccountId = accountId
            });
            dbContext.SaveChanges();
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }
    }

    public int GetAccountToLoan(int loanId)
    {
        try
        {
            
            return dbContext.AccountAndLoans.Where(a => a.LoanId == loanId).Select(a => a.AccountId).FirstOrDefault();
        }
        catch { return 0; }
    }
}
