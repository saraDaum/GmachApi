using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces;

public interface ILoanDetails
{
    /// <summary>
    /// Add new loan
    /// </summary>
    /// <param name="loanDetails">loan to add</param>
    /// <returns>the loan Id</returns>
    public int AddLoan(Models.LoanDetails loanDetails);

    /// <summary>
    /// Check if loand exist by its Id.
    /// </summary>
    /// <param name="loanId">the loan Id</param>
    /// <returns>true or false</returns>
    bool IsLoanExist(int loanId);

    /// <summary>
    /// change the loan status to approved
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    bool LoanApproval(int id);

    /// <summary>
    /// Get all not appoval loans.
    /// </summary>
    /// <returns>list of all the non approval loan requests</returns>
    List<Models.LoanDetails>? GetWaitingList();

    /// <summary>
    /// Get loans filter by predicate or get all
    /// </summary>
    /// <param name="predicate">predicate, or null</param>
    /// <returns>filter list of loan or all loans</returns>
    List<Models.LoanDetails>? getLoans(Func<Models.LoanDetails, bool>? predicate = null);

    /// <summary>
    /// Gets LoanId and delete the match loan from database.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    bool Delete(int id);

}
