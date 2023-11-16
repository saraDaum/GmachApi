using System;
using System.Collections.Generic;

namespace DTO.Models;

public partial class Account
{
    public int BorrowerId { get; set; }

    public int AcountsNumber { get; set; }

    public int BankNumber { get; set; }

    public int Branch { get; set; }

    public string ConfirmAcountFile { get; set; } = null!;//File TODO: Check if it's necessary

    public int AccontId { get; set; }

    public virtual Borrower Borrower { get; set; } = null!;

    public virtual ICollection<LoanDetails> Loans { get; set; } = new List<LoanDetails>();
}
