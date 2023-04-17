using System;
using System.Collections.Generic;

namespace Repositories.Models;

public partial class Depositor
{
    public int UserNumber { get; set; }

    public string UserName { get; set; } = null!;

    public int UserId { get; set; }

    public string UserAddress { get; set; } = null!;

    public int UserPhone { get; set; }

    public string UserEmail { get; set; } = null!;

    public virtual ICollection<Deposit> Deposits { get; set; } = new List<Deposit>();
}
