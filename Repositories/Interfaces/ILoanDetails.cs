using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces;

public interface ILoanDetails
{
    public int AddLoan(Models.LoanDetails loanDetails);
    public List<Models.LoanDetails> GetUserLoans(int userId);
    public List<Models.LoanDetails> GeAlltLoans();
    
}
