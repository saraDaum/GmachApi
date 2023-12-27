using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DTO.Models;
using Microsoft.Identity.Client;
using Repositories.Interfaces;

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
            if (!u.IsUserExist(loan.LoanerId)) 
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

    public List<Loan>? GetUserLoans(int userId)
    {
        try
        {
            IMapper mapper = LoanAutoMapper.LoanDetailsMapper.CreateMapper();
            List<Repositories.Models.LoanDetails>? loans = loanDetail.getLoans(l=> l.LoanerId == userId);
            if (loans == null)
                return null;
            List<Loan> loanDetails = loans.ConvertAll<Loan>(loan=> mapper.Map<Repositories.Models.LoanDetails, Loan>(loan) ) ;
            return loanDetails;
        }
        catch (Exception ex) {
            Console.WriteLine(ex.Message);
            return new List< Loan>();//TODO: Consider return object with paramameter to check if everything okey (an empty object).Sara.
        };
    }

    public List<Loan>? GetAllLoans() {
        IMapper mapper = LoanAutoMapper.LoanDetailsMapper.CreateMapper();
        List<Repositories.Models.LoanDetails>? AllLoans = loanDetail.getLoans();
        if (AllLoans == null)
            return null;
        List<Loan> AllLoansDetails = AllLoans.ConvertAll<DTO.Models.Loan>(loan => mapper.Map<Repositories.Models.LoanDetails, DTO.Models.Loan>(loan));
        return AllLoansDetails;
    }

    public Loan GetLoanDetails(int Id)
    {
        try
        {
            Repositories.Models.LoanDetails? l = loanDetail.getLoans(l => l.LoanId == Id)?.FirstOrDefault();
            if (l == null)
                throw new Exception("There is no loan wuth such id");
            IMapper mapper = LoanAutoMapper.LoanDetailsMapper.CreateMapper();
            return mapper.Map<Loan>(l);

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
            Loan loan = GetLoanDetails(loanID);
            IServices.IDeposit deposit = new Implemantation.Deposit();
            //check if there is enough money even during the loan time
            if (GetTheFinalBalanceByDate(DateTime.Today)- deposit.GetBalanceDifferenceByTwoDates(DateTime.Today, loan.DateToGetBack) < loan.Sum || IsBorrowerBlacklisted(loan))
                return false;
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
        // Get the balance of the association for today
        var todayBalance = GetTheFinalBalanceByDate(DateTime.Today);

        // Get the list of loan requests waiting for approval
        var waitingList = GetWaitingList();

        if (waitingList == null || !waitingList.Any())
            return null;

        // Sort the loans by the date to get back
        waitingList.Sort((a, b) => a.DateToGetBack.CompareTo(b.DateToGetBack));

        // Set the maximum loan amount per borrower and per request
        var maxAmountPerBorrower = 1000000m; // Example value, adjust as needed
        var maxAmountPerRequest = 200000m;  // Example value, adjust as needed

        // Create the result list for approved loans
        var approvedLoans = new List<DTO.Models.Loan>();

        foreach (var loanRequest in waitingList)
        {
            // Check if the borrower is blacklisted
            if (IsBorrowerBlacklisted(loanRequest))
                continue;

            // Check if the loan amount exceeds the maximum per request or per borrower
            if (loanRequest.Sum > maxAmountPerRequest || loanRequest.Sum + GetUserLoans(loanRequest.LoanerId)?.Sum(l => l.Sum) > maxAmountPerBorrower)
                continue;

            // Check if the association has enough balance to approve the loan and it doesn't impact future investments
            if (loanRequest.Sum <= todayBalance && !DoesLoanImpactFutureInvestments(loanRequest, approvedLoans))//TODO: Remember to minus a amount of SUM OF BITACHON
            {
                IServices.IDeposit deposit = new Implemantation.Deposit();
                if (todayBalance - deposit.GetBalanceDifferenceByTwoDates(DateTime.Today, loanRequest.DateToGetBack) < loanRequest.Sum)
                    continue;
                // Approve the loan
                approvedLoans.Add(loanRequest);

                // Update the available balance
                todayBalance -= loanRequest.Sum;
            }
        }

        // Return the list of approved loans
        return approvedLoans.Any() ? approvedLoans.Select(l=>l.LoanId).ToList() : null;
    }

    private bool IsBorrowerBlacklisted(Loan loan)
    {
        try
        {
            Repositories.Interfaces.IUser user = new Repositories.Implementation.User();
            if (user.IsUserUnderWarning(loan.LoanerId))
                return true;
            // every loan should have at least 2 guanarators
            Repositories.Interfaces.IGuarantor guarantor = new Repositories.Implementation.Guarantor();
            if ((guarantor.Get(g => g.LoanId == loan.LoanId).ToList().Count) < 2)
            {
                return true;
            }
            return false;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw new Exception("Error: IsBorrowerBlacklisted function catch an error", ex);
        }
        
    }

    private List<Loan>? GetWaitingList()
    {
        IMapper mapper = LoanAutoMapper.LoanDetailsMapper.CreateMapper();
        List<Repositories.Models.LoanDetails>? AllLoans = loanDetail.getLoans(l => !l.IsAprovied);
        if (AllLoans == null)
            return null;
        List<DTO.Models.Loan> AllLoansDetails = AllLoans.ConvertAll<DTO.Models.Loan>(loan => mapper.Map<Repositories.Models.LoanDetails, DTO.Models.Loan>(loan));
        return AllLoansDetails;
    }

    public IEnumerable<Loan>? GetAllTheLoansByDate(DateTime date)
    {
        try
        {
            IMapper mapper = LoanAutoMapper.LoanDetailsMapper.CreateMapper();
            List<DTO.Models.Loan> ans = new List<DTO.Models.Loan>();
            foreach(Repositories.Models.LoanDetails l in loanDetail.getLoans(l => l.IsAprovied == true && l.DateToGetBack > date)){
                ans.Add(mapper.Map<DTO.Models.Loan>(l));
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
            foreach (DTO.Models.Loan l in GetAllTheLoansByDate(date))
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
    public double GetTheFinalBalanceByDate (DateTime date)
    {
        try
        {
            // Receive the Deposits today balance
            Deposit deposit = new Deposit();
            double todayDepositsBalance = deposit.GetTheBalanceByDate(date);
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

    // Function to check if a new loan impacts future investments (recursive)
    public bool DoesLoanImpactFutureInvestments(Loan newLoan, List<Loan> approvedLoans)
    {
        try
        {
            
            approvedLoans.InsertRange(0, GetAllLoans().Where(l => l.IsAprovied));
            // Get the return date of the new loan
            DateTime newLoanReturnDate = newLoan.DateToGetBack;

            // Split the approved loans into two groups:
            // those with return dates before the new loan
            // and those with return dates after or equal to the new loan
            var loansBeforeNewLoan = approvedLoans.Where(loan => loan.DateToGetBack < newLoanReturnDate);
            var loansAfterNewLoan = approvedLoans.Where(loan => loan.DateToGetBack >= newLoanReturnDate);

            // Check whether the new loan affects investment returns at future dates
            bool doesImpact = CheckFutureInvestmentsImpact(newLoan, loansBeforeNewLoan, loansAfterNewLoan);

            return doesImpact;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw new Exception("Error: DoesLoanImpactFutureInvestments catch an exception", ex);
        }
    }


    // Check whether the new loan affects investment returns at future dates
    public bool CheckFutureInvestmentsImpact(Loan newLoan, IEnumerable<Loan> loansBeforeNewLoan, IEnumerable<Loan> loansAfterNewLoan)
    {
        // סכום ההלוואה החדשה
        decimal newLoanAmount = newLoan.Sum;

        // סכום ההלוואות המופקעות שיש להן החזר בתאריכים עתידיים
        decimal totalLoansBeforeNewLoan = loansBeforeNewLoan.Sum(loan => loan.Sum);

        // סכום ההלוואות המופקעות שיש להן החזר בתאריכים עתידיים כולל ההלוואה החדשה
        decimal totalLoansAfterNewLoan = loansAfterNewLoan.Sum(loan => loan.Sum) + newLoanAmount;

        // בדוק האם הסכום הכולל של ההלוואות המופקעות גדול מההחזר הצפוי
        return totalLoansAfterNewLoan > totalLoansBeforeNewLoan;
    }

    /// <summary>
    /// Delete a loan according to loan id that sent
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public bool Delete(int id)
    {
        try
        {
            return loanDetail.IsLoanExist(id);
        }
        catch
        {
            return false;
        }
    }
}

