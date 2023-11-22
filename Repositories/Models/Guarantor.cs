using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repositories.Models;


public partial class Guarantor
{
    [Key]
    public int Id { get; set; }

    public string IdentityNumber { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string EmailAddress {  get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public Account Account { get; set; }

}
