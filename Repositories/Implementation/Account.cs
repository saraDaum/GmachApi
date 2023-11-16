using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Implementation;

public class Account : Interfaces.IAcount
{
    private IDbContext dbContext;

    public Account(IDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
}
