using System;
using System.Collections.Generic;

namespace Repositories.Models;

public partial class Guarantor: User
{
    public int LoanId { get; set; }

    public virtual LoanDetails Loan { get; set; } = null!;
}
