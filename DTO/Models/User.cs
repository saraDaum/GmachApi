﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DTO.Models;

public partial class User
{

    public int UserId { get; set; } // מספר מזהה לקוח

    public string UserIdentityNumber { get; set; } = null!; // תעודת זהות

    public string UserName { get; set; } = null!;

    public string UserPassword { get; set; } = null!;
    
    public string UserEmail { get; set; } = null!;
    
    public string UserAddress { get; set; } = null!;

    public string UserPhone { get; set; } = null;


}

