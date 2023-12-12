using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DTO.Models;

public partial class Account
{
    
    public int AccontId { get; set; }

     public int UserId { get; set; }

    public string AccountsNumber { get; set; } = string.Empty;

    public string BankNumber { get; set; } = string.Empty;

    public string Branch { get; set; } = string.Empty;

    public string OwnerIdNumber { get; set; } = string.Empty;

    public string ConfirmAcountFile { get; set; } = string.Empty;
}
