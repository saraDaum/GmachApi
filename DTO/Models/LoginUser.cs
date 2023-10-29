using Azure.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Models;

/// <summary>
/// This entity sent from front side to back, and according to that details
/// the system checks if this user is already registed or not.
/// </summary>
public class LoginUser
{
    public string UserName { get; set; }

    public string Password { get; set; }
   


    //private UsernamePasswordCredential
}



