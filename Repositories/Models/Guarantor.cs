using System;
using System.Collections.Generic;

namespace Repositories.Models;

public partial class Guarantor : User
{
    public List<LoanDetails> LoanId { get; set; } = new List<LoanDetails>();

    public Account Account { get; set; }

}
