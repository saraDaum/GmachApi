using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repositories.Models;

public partial class Deposit
{
    [Key]
    public int DepositId { get; set; }

    [ForeignKey(nameof(Users.UserId))]
    public int UserId { get; set; }


    public int Sum { get; set; }

    public DateTime DateToPull { get; set; }

}
