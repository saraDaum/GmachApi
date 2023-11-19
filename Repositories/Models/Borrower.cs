using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repositories.Models;

public partial class Borrower: Users
{
    public virtual ICollection<Account> Acounts { get; set; } = new List<Account>();

    public virtual ICollection<LoanDetails> Loans { get; set; } = new List<LoanDetails>();

    // we can add here some file savers, but this is the basic version
}
