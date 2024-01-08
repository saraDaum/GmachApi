using DTO.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GmachApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        Services.IServices.IMessage _message = new Services.Implemantation.Message();

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


    }
}
