using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repositories.Models;

public partial class LoanDetails
{
    private int v;

    public LoanDetails()
    {
        LoanId= -1;
        LoanerId = -1;
        DateToGetBack = new DateTime();
        Sum = 0;
        UserId = -1;
      }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int LoanId { get; set; }

    [ForeignKey(nameof(Users.UserId))]
    public int LoanerId { get; set; }
    
    
    public DateTime DateToGetBack { get; set; }

    public int Sum { get; set; }

    public int UserId { get; set; }

    public string LoanFile { get; set; } = null!;

    public virtual ICollection<Guarantor> Guarantors { get; set; } = new List<Guarantor>();



}
