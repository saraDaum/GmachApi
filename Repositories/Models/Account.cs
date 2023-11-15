using System;
using System.Collections.Generic;

namespace Repositories.Models;

public partial class Account
{
    public int AccontId { get; set; }

    public int BorrowerId { get; set; }

    public int AcountsNumber { get; set; }

    public int BankNumber { get; set; }

    public int Branch { get; set; }

    public string ConfirmAcountFile { get; set; } = null!;

    public virtual Borrower Borrower { get; set; } = null!;

    public virtual ICollection<LoansDetail> Loans { get; set; } = new List<LoansDetail>();
}
