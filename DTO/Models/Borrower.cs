﻿using System;
using System.Collections.Generic;

namespace DTO.Models;

public partial class Borrower: Guarantor
{

    public string CopyId { get; set; } = null!;//File 

    public virtual ICollection<Account> Acounts { get; set; } = new List<Account>();

    public virtual ICollection<LoanDetails> Loans { get; set; } = new List<LoanDetails>();
}
/* public int GuarantorNumber { get; set; }//ID

    public string GuarantorName { get; set; } = null!;

    public int GuarantorId { get; set; }

    public string GuarantorAddress { get; set; } = null!;

    public int GuarantorPhone { get; set; }

    public string GuarantorEmail { get; set; } = null!;*/