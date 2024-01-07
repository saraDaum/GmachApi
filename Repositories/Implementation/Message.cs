using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Implementation
{
    public class Message
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

    }
}
