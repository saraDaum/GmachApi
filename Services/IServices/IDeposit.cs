using DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IServices;

public interface IDeposit
{
    int AddADeposit(Deposit newDeposit);
    IEnumerable<Deposit> AllUserDeposits(int id);
    List<Deposit> GetAll();
    List<Deposit> GetNotReturnedDeposits();
    List<Deposit> GetReturnedDeposits();
    IEnumerable<Deposit>? GetAllTheDepositsByDate(DateTime date);
    double GetTheBalanceByDate(DateTime date);
    double GetBalanceDifferenceByTwoDates(DateTime date1, DateTime date2);
    bool AddTimeToDeposit(int depositId, DateTime newReturningDay);
    bool Return(int depositId);
}
