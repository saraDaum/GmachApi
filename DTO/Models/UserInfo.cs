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
    public int UserId {  get; set; }

    public string UserIdentityNumber { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
    public string UserEmail { get; set; } = string.Empty;
    public string UserAddress { get; set; } = string.Empty;
    public int UserPhone { get; set; }


}
