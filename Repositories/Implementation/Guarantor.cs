using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Implementation;

public class Guarantor : Interfaces.IGuarantor
{
    private readonly IDbContext dbContext;

    public Guarantor(IDbContext dbContext)
    {
        this.dbContext=dbContext;
    }

    public Guarantor()
    {
        dbContext = new GmachimSaraAndShaniContext();
    }

    public int Add(Models.Guarantor item)
    {
        try
        {
            dbContext.Guarantors.Add(item);
            dbContext.SaveChanges();

            return item.Id;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return -1;
        }
    }
}
