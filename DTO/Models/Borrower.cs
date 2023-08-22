using System;
using System.Collections.Generic;

namespace DTO.Models;

public partial class Borrower: Guarantor
{

    public string CopyId { get; set; } = null!;//File 

    public virtual ICollection<Acount> Acounts { get; set; } = new List<Acount>();

    public virtual ICollection<LoansDetail> Loans { get; set; } = new List<LoansDetail>();
}
/* public int GuarantorNumber { get; set; }//ID

    public string GuarantorName { get; set; } = null!;

    public int GuarantorId { get; set; }

    public string GuarantorAddress { get; set; } = null!;

    public int GuarantorPhone { get; set; }

    public string GuarantorEmail { get; set; } = null!;*/