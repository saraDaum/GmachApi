using System;
using System.Collections.Generic;

namespace Repositories.Models;

public partial class Deposit
{
    public int DepositId { get; set; }

    public int UserId { get; set; }

    public int Sum { get; set; }

    public DateTime DateToPull { get; set; }

}
