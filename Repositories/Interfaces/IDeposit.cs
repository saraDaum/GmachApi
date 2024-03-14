using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces;

public interface IDeposit
{
    IEnumerable<Repositories.Models.Deposit> AllUserDeposits(int userId);
    int AddADeposit(Repositories.Models.Deposit aDeposit);
    IEnumerable<Repositories.Models.Deposit> GetAll();
    public List<Repositories.Models.Deposit> GetNotReturnedDeposits();
    public List<Repositories.Models.Deposit> GetReturnedDeposits();
    List<Models.Deposit>? GetAllTheDepositsByDate(DateTime date);
    Deposit Get(int depositId);
    bool Update(Deposit deposit);
    int GetDepositCreditCardId(int depositId);
    bool SetCreditCardToDeposit(int depositId, int CreditCardId);
    bool Return(int  depositId);
}
