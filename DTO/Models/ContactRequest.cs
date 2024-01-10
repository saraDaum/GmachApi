using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Models;

public class ContactRequest
{
    public int Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Header { get; set; } = string.Empty;
    public string Text { get; set; } = string.Empty;
    public bool Handled { get; set; } = false;
}
