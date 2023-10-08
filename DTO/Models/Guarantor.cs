using System;
using System.Collections.Generic;

namespace DTO.Models;

public partial class Guarantor 
{
    //Don't inherit from User becuase Guarantor have less feilds than User.
    public int GuarantorIdentityNumber { get; set; }// תעודת זהות

    public string GuarantorName { get; set; } = null!;

    public int GuarantorId { get; set; } // מספר מזהה ערב

    public string GuarantorAddress { get; set; } = null!;

    public int GuarantorPhone { get; set; }

    public string GuarantorEmail { get; set; } = null!;

   
}
