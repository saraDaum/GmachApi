using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Models;

public partial class Account
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string OwnerFullName { get; set; } = string.Empty;
    public string AccountNunber { get; set; } = string.Empty;
    public string BankNumber { get; set; } = string.Empty;
    public string BranchNumber { get; set; } = string.Empty;
}
