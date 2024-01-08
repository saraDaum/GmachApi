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
}

