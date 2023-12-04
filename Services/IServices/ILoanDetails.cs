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
    List<LoanDetails> GetAllLoans();
    public DTO.Models.LoanDetails GetLoanDetails(int userId);
    List<LoanDetails> GetUserLoans(int id);
}