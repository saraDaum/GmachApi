using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repositories.Models;

public partial class Account
{
    [Key]
    public int AccontId { get; set; }

    public int UserId { get; set; }

    
    public string AccountsNumber { get; set; }

    public string BankNumber { get; set; }

    public string Branch { get; set; }

    public string ConfirmAcountFile { get; set; } = null!;

    public virtual Borrower Borrower { get; set; } = null!;

    public virtual ICollection<LoansDetail> Loans { get; set; } = new List<LoansDetail>();
}
