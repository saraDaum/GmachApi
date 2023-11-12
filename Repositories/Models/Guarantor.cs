using System;
using System.Collections.Generic;

namespace Repositories.Models;

public partial class Guarantor
{
    public int UserNumber { get; set; }

    public int LoanId { get; set; }

    public string GuarantorName { get; set; } = null!;

    public int GuarantorId { get; set; }

    public string UserAddress { get; set; } = null!;

    public int UserPhone { get; set; }

    public string UserEmail { get; set; } = null!;

    public string UserPassword { get; set; } = null!;

    public virtual LoansDetail Loan { get; set; } = null!;
}
