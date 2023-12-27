using DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IServices;
public interface ILoanDetails
{
    /// <summary>
    /// Add a new loan request
    /// </summary>
    /// <param name="loan">the loan details</param>
    /// <param name="guarantors">the guarantors list, optional</param>
    /// <returns>the loan id</returns>
    public int AddLoan(Loan loan, List<Guarantor>? guarantors);

    /// <summary>
    /// Get all the loans
    /// </summary>
    /// <returns>all the existing loan</returns>
    List<Loan>? GetAllLoans();

    /// <summary>
    /// Get the loan details
    /// </summary>
    /// <param name="Id">the loan id</param>
    /// <returns>the loan details</returns>
    public Loan GetLoanDetails(int Id);

    /// <summary>
    /// Get a list of an recomend loans to confirm
    /// </summary>
    /// <returns>list with the loan's ids</returns>
    IEnumerable<int>? GetLoansToApproval();

    /// <summary>
    /// Get all the loans the user have.
    /// </summary>
    /// <param name="id">the user id</param>
    /// <returns>list of loans</returns>
    List<Loan>? GetUserLoans(int id);

    /// <summary>
    /// return if loan exist by it's id
    /// </summary>
    /// <param name="id">the loan id</param>
    /// <returns>true or false</returns>
    bool IsLoanExist(int id);

    /// <summary>
    /// approve a loan
    /// </summary>
    /// <param name="loanID">the loan id</param>
    /// <returns>success</returns>
    bool LoanApproval(int loanID);


    /// <summary>
    /// Get all the Loans that exist and active in a specipic date.
    /// </summary>
    /// <param name="date">the date</param>
    /// <returns>list of the loans.</returns>
    IEnumerable<Loan>? GetAllTheLoansByDate(DateTime date);

    /// <summary>
    /// return the balance of specific date (the loans only)
    /// </summary>
    /// <param name="date">the date</param>
    /// <returns>the balance</returns>
    double getTheBalanceByDate(DateTime date);


    /// <summary>
    /// get the final balance (all the invesments and the loan in a specific date
    /// </summary>
    /// <param name="date">the wantes date</param>
    /// <returns>the balance</returns>
    double GetTheFinalBalanceByDate(DateTime date);

    /// <summary>
    /// Check if Loan Impact Future Investments
    /// </summary>
    /// <param name="newLoan">the wanted loan</param>
    /// <param name="approvedLoans">wanted to approve loans</param>
    /// <returns>if there is an impact</returns>
    bool DoesLoanImpactFutureInvestments(Loan newLoan, List<Loan> approvedLoans, double todayBalance);

    /// <summary>
    /// Check the Future Investments Impact
    /// </summary>
    /// <param name="newLoan">the loan to check</param>
    /// <param name="loansBeforeNewLoan">all the approved loans that returns before the loan return date</param>
    /// <param name="loansAfterNewLoan">all the approved loans that returns after the loan return date</param>
    /// <returns>Is it any impact</returns>
    bool CheckFutureInvestmentsImpact(Loan newLoan, IEnumerable<Loan> loansBeforeNewLoan, double currentBalance);


    /// <summary>
    /// Gets loan id and delete the match loan  from data base.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    bool Delete(int id);
}