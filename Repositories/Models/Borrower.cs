using System;
using System.Collections.Generic;

namespace Repositories.Models;

public partial class Borrower : User
{
    public string CopyId { get; set; } = null!;

    public virtual ICollection<Acount> Acounts { get; set; } = new List<Acount>();

    public virtual ICollection<LoansDetail> Loans { get; set; } = new List<LoansDetail>();
}
