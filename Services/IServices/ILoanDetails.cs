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
}