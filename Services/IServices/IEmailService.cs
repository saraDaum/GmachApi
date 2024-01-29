using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IServices;

public interface IEmailService
{
    Task SendEmailAsync(DTO.Models.Email emailDetails);
}
