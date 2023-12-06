﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repositories.Models;

public partial class LoanDetails
{
    
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int LoanId { get; set; }

    [ForeignKey(nameof(Users.UserId))]
    public int UserId { get; set; }
    
    
    public DateTime DateToGetBack { get; set; }

    public int Sum { get; set; }

    public string LoanFile { get; set; } = null!;

    public virtual ICollection<Guarantor> Guarantors { get; set; } = new List<Guarantor>();

    public bool IsAprovied { get; set; }


}
