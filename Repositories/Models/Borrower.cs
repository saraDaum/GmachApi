using System;
using System.Collections.Generic;

namespace Repositories.Models;

public partial class Borrower : User
{
    public string CopyId { get; set; } = null!;

    public virtual ICollection<Acount> Acounts { get; set; } = new List<Acount>();

    public virtual ICollection<Models.LoanDetails> Loans { get; set; } = new List<Models.LoanDetails>();
}
