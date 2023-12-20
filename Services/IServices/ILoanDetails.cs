using DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IServices;
public interface ILoanDetails
{
    public int AddLoan(DTO.Models.Loan loan, List<DTO.Models.Guarantor>? guarantors);
    List<LoanDetails> GetAllLoans();
    public DTO.Models.LoanDetails GetLoanDetails(int userId);
    IEnumerable<int>? GetLoansToApproval();
    List<LoanDetails> GetUserLoans(int id);

    bool IsLoanExist(int id);
    bool LoanApproval(int loanID);


    /// <summary>
    /// Get all the Loans that exist and active in a specipic date.
    /// </summary>
    /// <param name="date">the date</param>
    /// <returns>list of the loans.</returns>
    IEnumerable<DTO.Models.LoanDetails>? GetAllTheLoansByDate(DateTime date);

    /// <summary>
    /// return the balance of specific date (the loans only)
    /// </summary>
    /// <param name="date">the date</param>
    /// <returns>the balance</returns>
    double getTheBalanceByDate(DateTime date);
}