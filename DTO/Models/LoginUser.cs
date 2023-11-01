using Azure.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
    [Required]
    public string UserName { get; set; } = string.Empty!;

    [Required]
    public string UserPassword { get; set; } = string.Empty!;   
   


    //private UsernamePasswordCredential
}



