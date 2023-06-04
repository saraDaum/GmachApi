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

    public Models.User? GetUser(Models.User? user)
    {
        return dbContext.User.FirstOrDefault(u=>user.UserId==u.UserId && user.UserPassword==u.UserPassword&&user.UserName==u.UserName);
    }
    public int SignIn(Models.User user)
    {
        try
        {
            dbContext.User.Add(user);
            dbContext.SaveChanges();
            return user.UserId;
            //todo: check if method returns correct new userid
        }
        catch
        {
            return -1;
        }

    }
}
