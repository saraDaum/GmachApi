using DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IServices;
public interface ILoanDetails
{
    public int AddLoan(DTO.Models.LoanDetails loan);
    public List< DTO.Models.LoanDetails> GetUserLoans(int userId);
    public List<DTO.Models.LoanDetails> GetAllLoans();
}