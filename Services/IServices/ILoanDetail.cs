using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IServices;

public interface ILoanDetail
{
    public int AddLoan(DTO.Models.LoansDetail loan);
}
