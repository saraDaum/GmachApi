using DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IServices;

public interface IMessage
{
    IEnumerable<DTO.Models.Message> GetUserMessages(int id);

    bool Add(DTO.Models.Message message);

    IEnumerable<ContactRequest> GetContacts(bool UnHandled = false);

    int AddContactRequest(ContactRequest contact);

    bool DeleteContact(int id);
    bool ChangeToHandled(int id);

    List<DTO.Models.Message> GetAll();
    Email? ReportALoan(ReportALoan report);
}
