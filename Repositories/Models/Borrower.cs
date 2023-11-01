﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repositories.Models;

public class Borrower : User
{
    public string Copy { get; set; }
    public virtual ICollection<Acount> Acounts { get; set; } = new List<Acount>();
    public virtual ICollection<LoanDetails> Loans { get; set; } = new List<LoanDetails>();

}

