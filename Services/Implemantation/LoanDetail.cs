using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implemantation;
public class LoanDetail :IServices.ILoanDetail
{
    public int AddLoan(DTO.Models.LoansDetail loan)
    {
        //check if the loan is possible
        //if yes send the loan detail to the data base
        Repositories.Models.LoansDetail DALLoanDetail = (Repositories.Models.LoansDetail)loan;
        return Repositories.Interfaces.ILoanDetail.AddLoan(DALLoanDetail);
        throw new NotImplementedException();
    }
}
