using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Models;

/// <summary>
/// This entity use to be send fron API to back. 
/// This entity has the minimal details.
/// Mabey, this entity is for using it in the application??
/// </summary>
public class UserInfo
{
    public int UserNumber { get; set; }

    public string UserName { get; set; }

    public string UserEmail { get; set; } = null!;

    public string UserPhone { get; set; } = null!;

    public string UserAddress { get; set; } = null!;

    public UserInfo() { 
        UserNumber = -1;
        UserName = "";
        UserEmail = ""; 
        UserPhone = "";
        UserAddress = "";
    }
}
