using System;
using System.Collections.Generic;

namespace Repositories.Models;

public partial class Borrower
{
    public int UserNumber { get; set; }

    public string UserName { get; set; } = null!;

    public int UserId { get; set; }

    public string UserAddress { get; set; } = null!;

    public int UserPhone { get; set; }

    public string UserEmail { get; set; } = null!;

    public string CopyId { get; set; } = null!;

    public virtual ICollection<Acount> Acounts { get; set; } = new List<Acount>();

    public virtual ICollection<LoansDetail> Loans { get; set; } = new List<LoansDetail>();
}
