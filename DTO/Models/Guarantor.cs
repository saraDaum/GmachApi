using System;
using System.Collections.Generic;

namespace DTO.Models;

public partial class Guarantor 
{
    public int Id { get; set; }
    public string IdentityNumber { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string EmailAddress { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public Account Account { get; set; }


}
