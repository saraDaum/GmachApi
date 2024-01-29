using Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implemantation;

public class EmailService : IEmailService
{
    public Task SendEmailAsync(DTO.Models.Email emailDetails)
    {
        var mail = "plusminusgmach@gmail.com";
        var pw = "plusminus15987532";

        var client = new SmtpClient("smtp-mail.outlook.com", 587)
        {
            EnableSsl = true,
            Credentials = new NetworkCredential(mail, pw)
        };

        return client.SendMailAsync(
            new MailMessage(from: mail,
                            to: emailDetails.email,
                            emailDetails.subject,
                            emailDetails.message));

    }
}
