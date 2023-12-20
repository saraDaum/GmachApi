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


    public int AddLoan(DTO.Models.Loan loan, List<DTO.Models.Guarantor>? guarantors = null)
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


            int res = loanDetail.AddLoan(DALLoanDetail); // the loan id

            if(guarantors != null)
            {
                Guarantor guarantor = new Guarantor();
                foreach(DTO.Models.Guarantor g in guarantors)
                {
                    g.LoanId = res;
                    guarantor.AddNewGuarantor(g);
                }
            }

            return res;

        }
        catch (Exception)
        {

            return -3;
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

    public bool IsLoanExist(int id)
    {
        try
        {
            return loanDetail.IsLoanExist(id);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }
    }

    public bool LoanApproval(int loanID)
    {
        try
        {
            return loanDetail.LoanApproval(loanID);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }
    }

    public IEnumerable<int>? GetLoansToApproval()
    {
        // 1. Receive the balance of the association

        //1.1  Resive the Deposits today balance
        Deposit deposit = new Deposit();
        double todayDepositsBalance = deposit.getTheBalanceByDate(DateTime.Today);
        //1.2  Recive the loans today balance
        double todayLoansBalance = getTheBalanceByDate(DateTime.Today);






        throw new NotImplementedException();
    }

    public IEnumerable<DTO.Models.LoanDetails>? GetAllTheLoansByDate(DateTime date)
    {
        try
        {
            List<Repositories.Models.LoanDetails> repoLoans = 
        }
        catch(Exception ex) { }



        throw new NotImplementedException();
    }

    public double getTheBalanceByDate(DateTime date)
    {
        throw new NotImplementedException();
    }
}

