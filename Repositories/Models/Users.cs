using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Models;

public partial class Users
{

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int UserId { get; set; }

    public string UserIdentityNumber { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
    public string UserPassword { get; set; } = string.Empty;
    public string UserEmail { get; set; } =string.Empty;
    public string UserAddress { get; set; } = string.Empty;
    public int UserPhone { get; set; }

}
