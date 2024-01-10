using AutoMapper;
using Castle.Core.Internal;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implemantation;

public class Message : IServices.IMessage
{

    readonly Repositories.Interfaces.IMessage _message = new Repositories.Implementation.Message();
    MapperConfig _mapperConfig = MapperConfig.Instance;

    /// <summary>
    /// Handale adding new Message
    /// </summary>
    /// <param name="message">The message</param>
    /// <returns>succces</returns>
    public bool Add(DTO.Models.Message message)
    {
        try
        {
            //Check that users are exist, that the message is not empty, and make sure that the message status is not-viwed.
            if (message.Text == "" || message.Text.IsNullOrEmpty())
                return false;

            IServices.IUser _user = new User();
                if (!_user.IsUserExist(message.ToUserId) || !_user.IsUserExist(message.FromUserId))
                    return false;

            message.Viewed = false;


            IMapper mapper = _mapperConfig.MessageMapper.CreateMapper();
            return _message.Add(mapper.Map<Repositories.Models.Message>(message));
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }
    }

    /// <summary>
    /// Get all the messages that the user has (sent and recived)
    /// </summary>
    /// <param name="id">  User id </param>
    /// <returns> The message list</returns>
    /// <exception cref="Exception"> If catch an error</exception>
    public IEnumerable<DTO.Models.Message> GetUserMessages(int id)
    {
        try
        {
            IMapper mapper = _mapperConfig.MessageMapper.CreateMapper();

            List<Repositories.Models.Message> userMessageList = _message.GetUserMessage(id).ToList();
             
            // Change the recived messages to be viewed
            foreach(Repositories.Models.Message message in userMessageList.Where(m => m.ToUserId == id && !m.Viewed)) 
            {
                message.Viewed = true;
                _message.Update(message);
            }

            return (from s in userMessageList
                    select mapper.Map<DTO.Models.Message>(s)).ToList(); 
                   
        }
        catch (Exception ex)
        { 
            Console.WriteLine(ex.Message);
            throw new Exception("Error in server logic in in the wanted request: " + ex.Message, ex);
        }
    }

    // Contact area

    /// <summary>
    /// Get all contact request
    /// </summary>
    /// <returns>The contacts list</returns>
    /// <exception cref="Exception">If catch an exception during the proccess</exception>
    public IEnumerable<DTO.Models.ContactRequest> GetContacts(bool UnHandled = false)
    {
        try
        {
            List<Repositories.Models.ContactRequest> repoContacts;
            if (UnHandled)
                repoContacts = _message.GetAllContacts(c => !c.Handled);
            else
                repoContacts = _message.GetAllContacts();

            
            IMapper mapper = _mapperConfig.ContactRequestsMapper.CreateMapper();
            return (from c in repoContacts
                    select mapper.Map<DTO.Models.ContactRequest>(c)).ToList();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw new Exception("Catch an Exception in GetContact in Services: " + ex.Message, ex);
        }
        
    }

    public int AddContactRequest(DTO.Models.ContactRequest contact)
    {
        try
        {
            contact.Handled = false;
            IMapper mapper = _mapperConfig.ContactRequestsMapper.CreateMapper();
            return _message.AddContact(mapper.Map<Repositories.Models.ContactRequest>(contact));
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return -1;
        }
    }

    public bool DeleteContact(int id)
    {
        try
        {
            if(_message.GetAllContacts(c => c.Id == id).Any())
            {
                return _message.DeleteContact(_message.GetAllContacts(c => c.Id == id).First());
            }
            return false;

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }
        
    }

    public bool ChangeToHandled(int id)
    {
        try
        {
            if (_message.GetAllContacts(c => c.Id == id && !c.Handled).Any())
                return _message.ChangeToHandled(id);
            return false;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }
    }

    public List<DTO.Models.Message> GetAll()
    {
        try
        {
            IMapper mapper = _mapperConfig.MessageMapper.CreateMapper();
            List<Repositories.Models.Message> userMessageList = _message.GetAll().ToList();
            if (userMessageList.Count > 0) {
                return (from s in userMessageList
                        select mapper.Map<DTO.Models.Message>(s)).ToList();
            }
            return new List<DTO.Models.Message>();
        }
        catch
        {
            return new List<DTO.Models.Message> ();
        }
    }
}

