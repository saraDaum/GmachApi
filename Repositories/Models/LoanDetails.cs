using System;
using System.Collections.Generic;

namespace Repositories.Models;

public partial class LoanDetails
{
    public int LoanId { get; set; }

    public DateTime DateToGetBack { get; set; }

    public int Sum { get; set; }

    public int BorrowerNumber { get; set; }

    public string LoanFile { get; set; } = null!;

    public virtual ICollection<Guarantor> Guarantors { get; set; } = new List<Guarantor>();

    public virtual ICollection<Account> AcountsNumbers { get; set; } = new List<Account>();

    public virtual ICollection<Borrower> Borrowers { get; set; } = new List<Borrower>();


}
