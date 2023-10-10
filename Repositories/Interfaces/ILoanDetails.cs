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
    public Models.LoanDetails GetLoanDetails(int userId);
}
