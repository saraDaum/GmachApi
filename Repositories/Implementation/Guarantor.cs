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

    public IEnumerable<Models.Guarantor> Get(Func<Models.Guarantor, bool>? func = null)
    {
        try
        {
            if (func == null)
                return dbContext.Guarantors.ToList();
            return dbContext.Guarantors.Where(func).ToList();

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw new Exception(ex.Message, ex);
        }
            
    }

    public List<Models.Guarantor> GetAll()
    {
        try
        {
            return dbContext.Guarantors.ToList();
        }
        catch
        {
            return new List<Models.Guarantor>();
        }
    }
}
