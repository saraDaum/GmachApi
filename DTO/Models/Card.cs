using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DTO.Models;

public partial class Card
{

    public int AccontId { get; set; }
    public int UserId { get; set; }
    public string CreditCardNumber { get; set; } = string.Empty;
    public string OwnersName { get; set; } = string.Empty;
    public string CVV { get; set; } = string.Empty;
    public DateTime Validity { get; set; } = DateTime.MinValue;
}
