using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Models
{
    public class LogInUser
    {
        public string UserName { get; set; } = null!;

        public string Password { get; set; } = null!;
    }
}
