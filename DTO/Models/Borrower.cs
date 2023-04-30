using System;
using System.Collections.Generic;

namespace DTO.Models;

public partial class Borrower: Guarantor
{
   /*public int UserNumber { get; set; }

   public string UserName { get; set; } = null!;

    public int UserId { get; set; }

    public string UserAddress { get; set; } = null!;

    public int UserPhone { get; set; }

    public string UserEmail { get; set; } = null!;*/

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