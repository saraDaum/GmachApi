using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Implementation;

public class LoanDetail : Interfaces.ILoanDetail
{
    public int AddLoan(LoansDetail loansDetail)
    {
        //todo: add to the data base the loan object

        return 133;
    }
}
