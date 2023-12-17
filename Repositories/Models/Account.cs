using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repositories.Models;

public partial class Account
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int AccontId { get; set; } 

    [ForeignKey(nameof(Users.UserId))]
    public int UserId { get; set; }
     public string AccountsNumber { get; set; } = string.Empty;

    public string BankNumber { get; set; } = string.Empty;

    public string Branch { get; set; } = string.Empty;

    public string OwnerIdNumber { get; set; } = string.Empty;

    public string ConfirmAcountFile { get; set; } = string.Empty;

}
