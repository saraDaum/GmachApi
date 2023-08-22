using System;
using System.Collections.Generic;

namespace DTO.Models;

public partial class User
{

    public int UserId { get; set; } // מספר מזהה לקוח

    public string UserIdentityNumber { get; set; } // תעודת זהות

    public string UserName { get; set; } = null!;

    public string UserPassword { get; set; } = null!;
    
    public string UserEmail { get; set; } = null!;
    
    public string UserAddress { get; set; } = null!;

    public int UserPhone { get; set; }


}

