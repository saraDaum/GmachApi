using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Implementation;

public static class RepoFactory
{
    public static IDbContext dbContext;
    public static Account account { get; }
    public static Card card { get; }
    public static Borrower borrower { get; }
    public static Deposit deposit { get; }
    public static Depositor depositor { get; }
    public static LoanDetails loanDetails { get; }
    public static User User { get; }

    static RepoFactory()
    {
        dbContext = new Models.GmachimSaraAndShaniContext();
        account = new Account(dbContext);
        card = new Card(dbContext);
        borrower = new Borrower(dbContext);
        deposit = new Deposit(dbContext);
        depositor = new Depositor(dbContext);
        loanDetails = new LoanDetails(dbContext);
        User = new User(dbContext);

    }

}
