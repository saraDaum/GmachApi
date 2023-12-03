using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IServices;

public interface IDeposit
{
    public IEnumerable<DTO.Models.Deposit> AllUserDeposits(int userId);

    public int AddADeposit(DTO.Models.Deposit newDeposit);
}
