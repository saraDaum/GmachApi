using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Models;

public partial class User
{

    [Key]
    public int UserId { get; set; }

    public int UserIdentityNumber { get; set; }
    public string UserName { get; set; }
    public string UserPassword { get; set; }
    public string UserEmail { get; set; }
    public string UserAddress { get; set; }
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
