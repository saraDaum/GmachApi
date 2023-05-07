using System;
using System.Collections.Generic;

namespace Repositories.Models;

public partial class Depositor : User
{
    public virtual ICollection<Deposit> Deposits { get; set; } = new List<Deposit>();
}
