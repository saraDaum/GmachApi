using System;
using System.Collections.Generic;

namespace DTO.Models;

public partial class User
{

    public int UserId { get; set; }
    public string UserIdentityNumber { get; set; }

    public string UserName { get; set; } = null!;


    public string UserAddress { get; set; } = null!;

    public int UserPhone { get; set; }

    public string UserEmail { get; set; } = null!;

    public string UserPassword { get; set; } = null!;
}

