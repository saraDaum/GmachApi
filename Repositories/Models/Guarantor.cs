using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repositories.Models;

[NotMapped]
public partial class Guarantor : Users
{
    public List<LoanDetails> LoanId { get; set; } = new List<LoanDetails>();

    public Account Account { get; set; }

}
