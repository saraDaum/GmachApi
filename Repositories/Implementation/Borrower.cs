using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Implementation;

public class Borrower : Interfaces.IBorrower
{
    private IDbContext dbContext;

    public Borrower(IDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
}
