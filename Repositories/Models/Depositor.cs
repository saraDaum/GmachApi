using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repositories.Models;

[NotMapped]
public partial class Depositor: Users
{
    public virtual ICollection<Deposit> Deposits { get; set; } = new List<Deposit>();
}
