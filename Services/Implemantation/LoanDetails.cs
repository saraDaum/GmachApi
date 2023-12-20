using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DTO.Models;
using Microsoft.Identity.Client;

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

    public List<DTO.Models.LoanDetails>? GetUserLoans(int userId)
    {
        try
        {
            IMapper mapper = LoanAutoMapper.LoanDetailsMapper.CreateMapper();
            List<Repositories.Models.LoanDetails>? loans = loanDetail.getLoans(l=> l.UserId == userId);
            if (loans == null)
                return null;
            List<DTO.Models.LoanDetails> loanDetails = loans.ConvertAll<DTO.Models.LoanDetails>(loan=> mapper.Map<Repositories.Models.LoanDetails, DTO.Models.LoanDetails>(loan) ) ;
            return loanDetails;
        }
        catch (Exception ex) {
            Console.WriteLine(ex.Message);
            return new List< DTO.Models.LoanDetails>();//TODO: Consider return object with paramameter to check if everything okey (an empty object).Sara.
        };
    }

    public List<DTO.Models.LoanDetails>? GetAllLoans() {
        IMapper mapper = LoanAutoMapper.LoanDetailsMapper.CreateMapper();
        List<Repositories.Models.LoanDetails>? AllLoans = loanDetail.getLoans();
        if (AllLoans == null)
            return null;
        List<DTO.Models.LoanDetails> AllLoansDetails = AllLoans.ConvertAll<DTO.Models.LoanDetails>(loan => mapper.Map<Repositories.Models.LoanDetails, DTO.Models.LoanDetails>(loan));
        return AllLoansDetails;
    }

    public DTO.Models.LoanDetails GetLoanDetails(int userId)
    {
        try
        {
            Repositories.Models.LoanDetails? l = loanDetail.getLoans(l => l.UserId == userId)?.FirstOrDefault();
            if (l == null)
                throw new Exception("This User doesn't have any loans");
            IMapper mapper = LoanAutoMapper.LoanDetailsMapper.CreateMapper();
            return mapper.Map<DTO.Models.LoanDetails>(l);

        }
        catch (Exception ex)
        {
            throw new Exception("Error: Catch exception in GetLoanDetails function", ex);
        }
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
        double todayBalance = GetTheFinalBalanceByDate(DateTime.Today);

        // 2. Get the list of loan requests that wait for approvation.
        List<DTO.Models.LoanDetails>? waitingList = GetWaitingList();
        if (waitingList == null)
            return null;

        // 3.





        throw new NotImplementedException();
    }

    private List<DTO.Models.LoanDetails>? GetWaitingList()
    {
        IMapper mapper = LoanAutoMapper.LoanDetailsMapper.CreateMapper();
        List<Repositories.Models.LoanDetails>? AllLoans = loanDetail.getLoans(l => !l.IsAprovied);
        if (AllLoans == null)
            return null;
        List<DTO.Models.LoanDetails> AllLoansDetails = AllLoans.ConvertAll<DTO.Models.LoanDetails>(loan => mapper.Map<Repositories.Models.LoanDetails, DTO.Models.LoanDetails>(loan));
        return AllLoansDetails;
    }

    public IEnumerable<DTO.Models.LoanDetails>? GetAllTheLoansByDate(DateTime date)
    {
        try
        {
            IMapper mapper = LoanAutoMapper.LoanDetailsMapper.CreateMapper();
            List<DTO.Models.LoanDetails> ans = new List<DTO.Models.LoanDetails>();
            foreach(Repositories.Models.LoanDetails l in loanDetail.getLoans(l => l.IsAprovied == true && l.DateToGetBack > date)){
                ans.Add(mapper.Map<DTO.Models.LoanDetails>(l));
            }
            return ans;

        }
        catch(Exception ex) 
        {
            Console.WriteLine(ex.Message);
            throw new Exception("Error: Catch an exception in GetAllTheLoansByDate function", ex);
        }
    }

    public double getTheBalanceByDate(DateTime date)
    {
        try
        {
            double balance = 0;
            foreach (DTO.Models.LoanDetails l in GetAllTheLoansByDate(date))
            {
                balance += l.Sum;
            }
            return balance;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw new Exception("Error: Catch an exception in getTheBalanceByDate function", ex);
        }
    }

    // Helping function 
    double GetTheFinalBalanceByDate (DateTime date)
    {
        try
        {
            // Receive the Deposits today balance
            Deposit deposit = new Deposit();
            double todayDepositsBalance = deposit.getTheBalanceByDate(date);
            // Receive the loans today balance
            double todayLoansBalance = getTheBalanceByDate(date);

            return todayDepositsBalance - todayLoansBalance;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw new Exception("Error: Catch an exception in GetTheFinalBalanceByDate function", ex);
        }

    }
}

