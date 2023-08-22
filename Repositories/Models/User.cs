using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Models;

public partial class User
{
    public int UserIdentityNumber { get; set; }
   
    public int UserId { get; set; }//TODO: check what the difference between this and the user number

    //Answer: UserIdentityNumber = תעודת זהות and UserId  = מספר לקוח, מספור אוטומטי. Sara. After reading - delete.
    
    public string UserName { get; set; } = null!;

    public string UserPassword { get; set; } = null!;

    public string UserEmail { get; set; } = null!;

    public string UserAddress { get; set; } = null!;

    public int UserPhone { get; set; }
}
