using Repositories.Interfaces;
using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Implementation;

public class Message : IMessage
{
    private readonly IDbContext dbContext;

    //Constructors
    public Message(IDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    
    public Message()
    {
        dbContext = new GmachimSaraAndShaniContext();
    }

    /// <summary>
    /// Get the User's messages from the server
    /// </summary>
    /// <param name="id">The user id</param>
    /// <returns>The messages list</returns>
    /// <exception cref="Exception">Catch error that sent from the sql server</exception>
    public IEnumerable<Models.Message> GetUserMessage(int id)
    {
        try
        {
            return dbContext.Message.Where(m => m.FromUserId == id || m.ToUserId == id).ToList();
        }
        catch(Exception ex) 
        {
            Console.WriteLine(ex.Message);
            throw new Exception("Error getting the information from the server", ex);
        }
    }


    /// <summary>
    /// Add new message to the data base
    /// </summary>
    /// <param name="message">The message</param>
    /// <returns>success</returns>
    public bool Add(Models.Message message)
    {
        try
        {
            dbContext.Message.Add(message);
            dbContext.SaveChanges();
            return true;
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }
    }

    /// <summary>
    /// Update Message
    /// </summary>
    /// <param name="message">The message to update</param>
    /// <returns>success</returns>
    public bool Update(Models.Message message)
    {
        try
        {
            dbContext.Message.Update(message);
            dbContext.SaveChanges();
            return true;
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }
    }
}
