﻿using DTO.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Services.IServices;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GmachApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        Services.IServices.IMessage _message = new Services.Implemantation.Message();
        Services.IServices.IEmailService _emailSender = new Services.Implemantation.EmailService();



        [HttpGet("GetMessagesByUserId")]
        public IEnumerable<DTO.Models.Message> GetMessagesByUserId(int id)
        {
            try
            {
                return _message.GetUserMessages(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new List<Message>();
            }
        }


        [HttpPost("SendNewMessage")]
        public bool SendNewMessage(DTO.Models.Message message)
        {
            try
            {
                return _message.Add(message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        [HttpGet("GetAll")]
        public List<DTO.Models.Message> GetAll()
        {
            try
            {
                return _message.GetAll();
            }
            catch
            {
                return new List<Message>();
            }
        }

        // Contact Requests area:

        [HttpGet("GetAllContacts")]
        [Authorize(Policy = "AdminOnly")]
        public IEnumerable<ContactRequest> GetAllContacts()
        {
            try
            {
                return _message.GetContacts();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new List<ContactRequest>();
            }
        }

        [HttpGet("GetAllUnHandledContacts")] 
        [Authorize(Policy = "AdminOnly")]
        public IEnumerable<ContactRequest> GetAllUnHandledContacts()
        {
            try
            {
                return _message.GetContacts(true);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new List<ContactRequest>();
            }
        }

        [HttpPost("AddNewContactRequest")]
        public int AddNewContactRequest(ContactRequest contact)
        {
            try
            {
                return _message.AddContactRequest(contact);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return -1;
            }
        }

        [HttpDelete("{id}")]
        public bool DeleteContactRequest(int id)
        {
            try
            {
                return _message.DeleteContact(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        [HttpGet("ChangeToHandled")]
        public bool ChangeToHandled(int id)
        {
            try
            {
                return _message.ChangeToHandled(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        [HttpPost("SendEmailToUser")]
        [Authorize(Policy = "AdminOnly")]
        public async void SendEmailToUser(Email email)
        {
            try
            {
                await _emailSender.SendEmailAsync(email);
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
               
            }
        }


        /// <summary>
        /// send email and message in the user zone that tell the user about a problem in it's loan request
        /// </summary>
        /// <param name="report">the loan id and the message</param>
        [HttpPost("ReportLoan")]
        [Authorize(Policy = "AdminOnly")]
        public async void ReportLoan(ReportALoan report)
        {
            try
            {
                Email? email = _message.ReportALoan(report, true);
                if (email != null)
                    await _emailSender.SendEmailAsync(email);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);

            }
        }

        [HttpPost("DeleteLoneMessage")]
        public async void DeleteLoneMessage(int loanId)
        {
            try
            {
                Email? email = _message.ReportALoan(new ReportALoan() { LoanID = loanId}, false);
                if (email != null)
                    await _emailSender.SendEmailAsync(email);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);

            }
        }



    }
}
