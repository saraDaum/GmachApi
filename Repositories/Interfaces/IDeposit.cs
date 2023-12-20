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

    List<Models.Deposit>? GetAllTheDepositsByDate(DateTime date);



}
