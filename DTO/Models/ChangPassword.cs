using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Models;

public class ChangPassword
{
    public string UserName { get; set; } 
    public string OldPassword { get; set; }
    public string NewPassword { get; set; }

}
