using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Implementation;

public class Factory
{
    //IDbContext dbContext = Models.GmachimSaraAndShaniContext;
    static Account account { get; }
    static Borrower borrower { get; }
    static Deposit deposit { get; }
    static Depositor depositor { get; }
    static LoanDetails loanDetails { get; }
    static User user { get; }



}
