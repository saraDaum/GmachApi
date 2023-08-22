using System;
using System.Collections.Generic;

namespace DTO.Models;

public partial class LoansDetail
{
    public int LoanId { get; set; }

    public DateOnly DateToGetBack { get; set; }  // I change it to be DateOnly type instead of 'DataTime'. Sara.

    public DateOnly dateOfTakeLoan { get; set; } // I add this field. Sara.

    public int Sum { get; set; }

    public int BorrowerNumber { get; set; }

    public string LoanFile { get; set; } = null!;

    public virtual ICollection<Guarantor> Guarantors { get; set; } = new List<Guarantor>();

    public virtual ICollection<Acount> AcountsNumbers { get; set; } = new List<Acount>();

    public virtual ICollection<Borrower> Borrowers { get; set; } = new List<Borrower>();
}
