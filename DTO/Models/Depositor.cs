using System;
using System.Collections.Generic;

namespace DTO.Models;

public partial class Depositor:Guarantor
{
    /*public int UserNumber { get; set; }

    public string UserName { get; set; } = null!;

    public int UserId { get; set; }

    public string UserAddress { get; set; } = null!;

    public int UserPhone { get; set; }

    public string UserEmail { get; set; } = null!;*/

    public virtual ICollection<Deposit> Deposits { get; set; } = new List<Deposit>();
}
