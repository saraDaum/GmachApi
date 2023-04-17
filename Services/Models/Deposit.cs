using System;
using System.Collections.Generic;

namespace Services.Models;

public partial class Deposit
{
    public int DepositId { get; set; }

    public int DepositorsId { get; set; }

    public int Sum { get; set; }

    public DateTime DateToPull { get; set; }

    public virtual Depositor Depositors { get; set; } = null!;
}
