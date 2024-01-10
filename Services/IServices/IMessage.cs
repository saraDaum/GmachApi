using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IServices
{
    public interface IMessage
    {
        IEnumerable<DTO.Models.Message> GetUserMessages(int id);

        bool Add(DTO.Models.Message message);

        List<DTO.Models.Message> GetAll();

    }
}
