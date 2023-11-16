using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Implementation;

public class Depositor : Interfaces.IDepositor
{
    private IDbContext dbContext;

    public Depositor(IDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
}
