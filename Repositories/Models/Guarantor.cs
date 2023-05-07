using System;
using System.Collections.Generic;

namespace Repositories.Models;

public partial class Guarantor: User
{
    public int LoanId { get; set; }

    public virtual LoansDetail Loan { get; set; } = null!;
}
