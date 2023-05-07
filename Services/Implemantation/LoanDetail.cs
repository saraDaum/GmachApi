using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Services.Implemantation;
public class LoanDetail :IServices.ILoanDetail
{
    Mapper AutoMapper = new Mapper();
    Repositories.Interfaces.ILoanDetail loanDetail = new Repositories.Implementation.LoanDetail();
    public int AddLoan(DTO.Models.LoansDetail loan)
    {
        //todo: the logic is here!
        //check if the loan is possible
        //if yes send the loan detail to the data base
        IMapper mapper = AutoMapper.LoanDetailConfiguration.CreateMapper();
        Repositories.Models.LoansDetail DALLoanDetail = mapper.Map<DTO.Models.LoansDetail, Repositories.Models.LoansDetail>(loan);
        //Enter to DB
        return loanDetail.AddLoan(DALLoanDetail);
        //throw new NotImplementedException();
    }
}
