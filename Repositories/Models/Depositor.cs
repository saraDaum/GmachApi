using System;
using System.Collections.Generic;

namespace Repositories.Models;

public partial class Depositor: Users
{
    public virtual ICollection<Deposit> Deposits { get; set; } = new List<Deposit>();
}
