using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Repositories.Models;

public partial class LoanDetails
{
    [Key]
    public int LoanId { get; set; }


    public DateTime DateToGetBack { get; set; }

    public int Sum { get; set; }

    public int UserId { get; set; }

    public string LoanFile { get; set; } = null!;

    public virtual ICollection<Guarantor> Guarantors { get; set; } = new List<Guarantor>();



}
