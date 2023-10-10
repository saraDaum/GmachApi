using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Implementation;

public class LoanDetail : Interfaces.ILoanDetail
{
    public LoanDetail()
    {

    }

    private readonly IDbContext dbContext;
    public LoanDetail(IDbContext ctx)
    {
        dbContext = ctx;
    }

    public int AddLoan(LoansDetail loansDetail)
    {
        //todo: add to the data base the loan object

        return 133;
    }
    public LoansDetail GetLoansDetail(int userId)
    {
        return (LoansDetail)dbContext.LoansDetails.Where(loan => loan.BorrowerNumber == userId);
        return new LoansDetail();
    }
}
