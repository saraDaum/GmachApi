using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Models;

public partial class Account
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int AccountId { get; set; }
    public int UserId {  get; set; }
    public string OwnerFullName { get; set; } = string.Empty;
    public string AccountsNunber { get; set; } = string.Empty;
    public string BankNumber { get; set; } = string.Empty;
    public string Branch { get; set;} = string.Empty;

}
