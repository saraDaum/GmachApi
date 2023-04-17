using System;
using System.Collections.Generic;

namespace Services.Models;

public partial class Acount
{
    public int BorrowerId { get; set; }

    public int AcountsNumber { get; set; }

    public int BankNumber { get; set; }

    public int Branch { get; set; }

    public string ConfirmAcountFile { get; set; } = null!;

    public int AccontId { get; set; }

    public virtual Borrower Borrower { get; set; } = null!;

    public virtual ICollection<LoansDetail> Loans { get; set; } = new List<LoansDetail>();
}
