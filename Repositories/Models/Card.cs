using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repositories.Models;

public partial class Card
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int AccontId { get; set; } 

    [ForeignKey(nameof(Users.UserId))]
    public int UserId { get; set; }

        public string CreditCardNumber { get; set; } = string.Empty;

    public string OwnersName { get; set; } = string.Empty;

    public string CVV { get; set; } = string.Empty;

    public DateTime Validity { get; set; } = DateTime.MinValue;

}
