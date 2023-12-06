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
    Repositories.Implementation.LoanDetails loanDetail = new Repositories.Implementation.LoanDetails();


    public int AddLoan(DTO.Models.LoanDetails loan)
    {
        try
        {
            //check if user exist
            User u = new User();
            if (!u.IsUserExist(loan.UserId)) 
            { 
                return -1;
            }


            IMapper mapper = LoanAutoMapper.LoanDetailsMapper.CreateMapper();
            Repositories.Models.LoanDetails DALLoanDetail = mapper.Map<Repositories.Models.LoanDetails>(loan);

            //save the guanarators

            

            int res = loanDetail.AddLoan(DALLoanDetail);

            return res;

        }
        catch (Exception)
        {

            throw;
        }
    }

    public List<DTO.Models.LoanDetails> GetUserLoans(int userId)
    {
        try
        {
            IMapper mapper = LoanAutoMapper.LoanDetailsMapper.CreateMapper();
            List<Repositories.Models.LoanDetails> loans = loanDetail.GetUserLoans(userId);
            List<DTO.Models.LoanDetails> loanDetails = loans.ConvertAll<DTO.Models.LoanDetails>(loan=> mapper.Map<Repositories.Models.LoanDetails, DTO.Models.LoanDetails>(loan) ) ;
            return loanDetails;
        }
        catch (Exception ex) {
            Console.WriteLine(ex.Message);
            return new List< DTO.Models.LoanDetails>();//TODO: Consider return object with paramameter to check if everything okey (an empty object).Sara.
        };
    }


    public List<DTO.Models.LoanDetails> GetAllLoans() {
        IMapper mapper = LoanAutoMapper.LoanDetailsMapper.CreateMapper();
        List<Repositories.Models.LoanDetails> AllLoans = loanDetail.GeAlltLoans();
        List<DTO.Models.LoanDetails> AllLoansDetails = AllLoans.ConvertAll<DTO.Models.LoanDetails>(loan => mapper.Map<Repositories.Models.LoanDetails, DTO.Models.LoanDetails>(loan));
        return AllLoansDetails;
    }

    public DTO.Models.LoanDetails GetLoanDetails(int userId)
    {
        throw new NotImplementedException();
    }
}

