using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Implementation;

public class LoanDetails : Interfaces.ILoanDetails
{
    public LoanDetails()
    {
        //LoanId = 0;
        //Sum = 0;

    }

    private readonly IDbContext dbContext;
    public LoanDetails(IDbContext ctx)
    {
        dbContext = ctx;
    }

    public int AddLoan(Models.LoanDetails loansDetail)
    {
        //todo: add to the data base the loan object

        return 133;
    }
    public Models.LoanDetails GetLoanDetails(int userId)
    {
        return (Models.LoanDetails)dbContext.LoanDetails.Where(loan => loan.UserId == userId);
        return new Models.LoanDetails();
    }
}
