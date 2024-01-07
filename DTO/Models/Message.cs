using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Models
{
    public partial class Message
    {
        public int FromUserId { get; set; } 
        public int ToUserId { get; set; }
        public string Text { get; set; } = string.Empty;


    }
}
