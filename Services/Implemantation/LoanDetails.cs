using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DTO.Models;

namespace Services.Implemantation;

public class LoanDetails : IServices.ILoanDetails
{
    MapperConfig LoanAutoMapper = MapperConfig.Instance;
    Repositories.Interfaces.ILoanDetails loanDetail = new Repositories.Implementation.LoanDetails();
    public int AddLoan(DTO.Models.LoanDetails loan)
    {
        IMapper mapper = LoanAutoMapper.LoanDetailsMapper.CreateMapper();
        //todo: the logic is here!
        //check if the loan is possible
        //if yes send the loan detail to the data base
        Repositories.Models.LoanDetails DALLoanDetail = mapper.Map<DTO.Models.LoanDetails, Repositories.Models.LoanDetails>(loan);
        //Enter to DB
        return loanDetail.AddLoan(DALLoanDetail);
        //throw new NotImplementedException();
    }

    public DTO.Models.LoanDetails GetLoanDetails(int userId)
    {
        IMapper mapper = LoanAutoMapper.LoanDetailsMapper.CreateMapper();
        return new DTO.Models.LoanDetails();//to change it!!
       // Repositories.Models.LoansDetail loan = mapper.Map<>
    }
}
