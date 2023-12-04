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
}
