using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Models
{
    public partial class User
    {
        public int UserNumber { get; set; }

        public string UserName { get; set; } = null!;

        public int UserId { get; set; }

        public string UserAddress { get; set; } = null!;

        public int UserPhone { get; set; }

        public string UserEmail { get; set; } = null!;

        public string UserPassword { get; set; } = null!;
    }
}
