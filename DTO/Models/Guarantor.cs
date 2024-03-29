﻿using System;
using System.Collections.Generic;

namespace DTO.Models;

public partial class Guarantor 
{
    public int Id { get; set; }
    public int LoanId { get; set; }
    public string IdentityNumber { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string EmailAddress { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string Check { get; set; } = string.Empty; //Link of the check image

}
