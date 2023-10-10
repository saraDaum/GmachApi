using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Models;

public partial class User
{
    public int UserIdentityNumber { get; set; }//תז
   
    public int UserId { get; set; }//מזהה לקוח

    public string UserName { get; set; } = null!;

    public string UserPassword { get; set; } = null!;

    public string UserEmail { get; set; } = null!;

    public string UserAddress { get; set; } = null!;

    public int UserPhone { get; set; }

    public User()
    {
        UserId = 0;
        UserIdentityNumber = 0;
        UserName = null!;
        UserPassword = null!;
        UserEmail= null!;
        UserAddress = null!;
        UserPhone = 0;

    }
}
