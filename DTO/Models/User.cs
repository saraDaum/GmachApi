using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DTO.Models;

public partial class User
{
    public int UserId { get; set; } // מספר מזהה לקוח
    public string UserIdentityNumber { get; set; } = string.Empty; // תעודת זהות
    public string UserName { get; set; } = string.Empty;
    public string UserPassword { get; set; } = string.Empty;
    public string UserEmail { get; set; } = string.Empty;
    public string UserAddress { get; set; } = string.Empty;
    public int UserPhone { get; set; } 


}

