using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTO.Models;

public partial class LoanDetails
{
    public int LoanId { get; set; }
    public int UserId { get; set; }


    public DateTime DateToGetBack { get; set; }

    public int Sum { get; set; }

    public string LoanFile { get; set; } = string.Empty;

    public bool IsAprovied { get; set; }

    public List<Guarantor>? guarantors { get; set; } = null;
}
