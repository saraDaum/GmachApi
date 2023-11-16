using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Implementation;

public class Factory
{
    //IDbContext dbContext = Models.GmachimSaraAndShaniContext;
    static Account account { get; } = null!;
    static Borrower borrower { get; } = null!;
    static Deposit deposit { get; } = null!;
    static Depositor depositor { get; } = null!;
    static LoanDetails loanDetails { get; } = null!;
    static User user { get; }



}
