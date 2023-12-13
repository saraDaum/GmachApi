using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DTO.Models;

public partial class Card
{
    public int CardId { get; set; }
    public int UserId { get; set; }
    public string CreditCardNumber { get; set; } = string.Empty;
    public string OwnersName { get; set; } = string.Empty;
    public string CVV { get; set; } = string.Empty;
    public string Validity { get; set; } = string.Empty;
}
