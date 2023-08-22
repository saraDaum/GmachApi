using System;
using System.Collections.Generic;

namespace DTO.Models;

public partial class Guarantor 
{
    public int GuarantorNumber { get; set; }// תעודת זהות

    public string GuarantorName { get; set; } = null!;

    public int GuarantorId { get; set; } // מספר מזהה לקוח

    public string GuarantorAddress { get; set; } = null!;

    public int GuarantorPhone { get; set; }

    public string GuarantorEmail { get; set; } = null!;

   
}
