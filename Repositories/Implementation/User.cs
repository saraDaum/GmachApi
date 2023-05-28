using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Implementation;

public class User : Interfaces.IUser
{
    private readonly IDbContext dbContext;
    public User(IDbContext ctx)
    {
        dbContext = ctx;
    }
    public Models.User? Login(string userName, string Password)
    {
        
        return dbContext.User.Where(a => a.UserName == userName && a.UserPassword == Password).FirstOrDefault();
 
    }
    
}
