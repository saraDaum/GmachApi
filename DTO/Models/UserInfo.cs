using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Models;

public class UserInfo
{
    public int UserNumber { get; set; }
    public string UserName { get; set; }
    public string UserEmail { get; set; } = null!;
    public string UserPhone { get; set; } = null!;
    public string UserAddress { get; set; } = null!;
}
