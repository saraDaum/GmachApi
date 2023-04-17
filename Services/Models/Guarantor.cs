using System;
using System.Collections.Generic;

namespace Services.Models;

public partial class Guarantor
{
    public int GuarantorNumber { get; set; }

    public string GuarantorName { get; set; } = null!;

    public int GuarantorId { get; set; }

    public string GuarantorAddress { get; set; } = null!;

    public int GuarantorPhone { get; set; }

    public string GuarantorEmail { get; set; } = null!;

    public int SumOfGuarantee { get; set; }

    public int LoanId { get; set; }

    public virtual LoansDetail Loan { get; set; } = null!;
}
