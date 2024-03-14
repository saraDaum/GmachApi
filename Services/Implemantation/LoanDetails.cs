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


    public int AddLoan(DTO.Models.Loan loan, int BanckAccountId, List<DTO.Models.Guarantor>? guarantors = null)
    {
        try
        {
            //check if user exist
            User u = new User();
            if (!u.IsUserExist(loan.LoanerId))
            {
                return -1;
            }
            // Check if the user own the account
            Account account = new Account();
            if (!account.IsAccountExistByUserId(loan.LoanerId))
                return -2;

            IMapper mapper = LoanAutoMapper.LoanDetailsMapper.CreateMapper();
            Repositories.Models.LoanDetails DALLoanDetail = mapper.Map<Repositories.Models.LoanDetails>(loan);


            int res = loanDetail.AddLoan(DALLoanDetail); // the loan id

            if (guarantors != null)
            {
                Guarantor guarantor = new Guarantor();
                foreach (DTO.Models.Guarantor g in guarantors)
                {
                    g.LoanId = res;
                    guarantor.AddNewGuarantor(g);
                }
            }

            bool ans = loanDetail.SetAccountToLoan(res, BanckAccountId);
            if (!ans)
                return -5;

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
            List<Repositories.Models.LoanDetails>? loans = loanDetail.getLoans(l => l.LoanerId == userId);
            if (loans == null)
                return null;
            List<Loan> loanDetails = loans.ConvertAll<Loan>(loan => mapper.Map<Repositories.Models.LoanDetails, Loan>(loan));
            return loanDetails;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return new List<Loan>();//TODO: Consider return object with paramameter to check if everything okey (an empty object).Sara.
        };
    }

    public List<Loan>? GetAllLoans()
    {
        IMapper mapper = LoanAutoMapper.LoanDetailsMapper.CreateMapper();
        List<Repositories.Models.LoanDetails>? AllLoans = loanDetail.getLoans();
        if (AllLoans == null)
            return null;
        List<Loan> AllLoansDetails = AllLoans.ConvertAll<DTO.Models.Loan>(loan => mapper.Map<Repositories.Models.LoanDetails, DTO.Models.Loan>(loan));
        return AllLoansDetails;
    }

    public List<DTO.Models.LoanDetails>? GetAllLoansDetails()
    {
        /* IMapper mapper = LoanAutoMapper.LoanDetailsMapper.CreateMapper();
         List<Repositories.Models.LoanDetails>? AllLoans = loanDetail.getLoans();
         if (AllLoans == null)
             return null;
         List<LoanDetails> AllLoansDetails = AllLoans.ConvertAll<DTO.Models.LoanDetails>(loan => mapper.Map<Repositories.Models.LoanDetails, DTO.Models.LoanDetails>(loan));
         return AllLoansDetails;*/


        IMapper mapper = LoanAutoMapper.LoanDetailsMapper.CreateMapper();
        //All loans without the guarantors.
        List<Repositories.Models.LoanDetails>? AllLoans = loanDetail.getLoans();
        if (AllLoans == null)
            return null;
        //Map all loans to be DTO type
        List<DTO.Models.LoanDetails> allLoansDetails = new List<DTO.Models.LoanDetails>();
        foreach (var loan in AllLoans)
        {
            int accountId = loanDetail.GetAccountToLoan(loan.LoanId);
            if (accountId < 0)
                continue;
            DTO.Models.LoanDetails loanDetails = new DTO.Models.LoanDetails
            {
                LoanId = loan.LoanId,
                LoanerId = loan.LoanerId,
                DateToGetBack = loan.DateToGetBack,
                Sum = loan.Sum,
                LoanFile = loan.LoanFile,
                IsAprovied = loan.IsAprovied,
                guarantors = GetLoanGuarantor(loan.LoanId),//Add guarantors to entity.
                AccountId =  accountId

            };
            allLoansDetails.Add(loanDetails);
        }
        if (allLoansDetails.Count> 0)
        return allLoansDetails;
        return null;
    }

    public List<DTO.Models.Guarantor>? GetLoanGuarantor(int loanId)
    {
        Services.Implemantation.Guarantor GuarantorHelpVar = new Services.Implemantation.Guarantor();
        List<DTO.Models.Guarantor> allGuarantors = GuarantorHelpVar.GetAll();
        List<DTO.Models.Guarantor> Guarantors = new List<DTO.Models.Guarantor>();//An empty list. If there are guarantors for this loan- we will add them in.
        foreach (var g in allGuarantors)
        {
            if (g.LoanId == loanId)
                Guarantors.Add(g);
        }
        if (Guarantors != null && Guarantors.Count != 0)
            return Guarantors;
        return null;

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
            if (GetTheFinalBalanceByDate(DateTime.Today) - deposit.GetBalanceDifferenceByTwoDates(DateTime.Today, loan.DateToGetBack) < loan.Sum || IsBorrowerBlacklisted(loan))
                return false;
            return loanDetail.LoanApproval(loanID);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }
    }


    /// <summary>
    /// This function is an algorithm that calculates for each loan request
    /// whether its approval endangers the stability of the association. 
    /// The algorithm checks whether the approval of this loan will mean that the association 
    /// will not be able to return their money to the donors? 
    /// If there is a risk, the algorithm will advise the director of the associations to refrain from approving the request. 
    /// If there is no risk, the algorithm will recommend the director of the association to approve the request.
    /// </summary>
    /// <returns></returns>
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
        var maxAmountPerBorrower = 50000m; // Per user
        var maxAmountPerRequest = 200000m;  // Per loan

        // Create the result list for approved loans
        List<DTO.Models.Loan> approvedLoans = new List<DTO.Models.Loan>();

        foreach (var loanRequest in waitingList)
        {
            // Check if loan asociate with valid account
            if (loanDetail.GetAccountToLoan(loanRequest.LoanId) <= 0)
                continue;

            // Check if the borrower is blacklisted
            if (IsBorrowerBlacklisted(loanRequest) || !IsLoanSafe(loanRequest.LoanId))
                continue;


            // Check if the loan amount exceeds the maximum per request or per borrower
            if (loanRequest.Sum > maxAmountPerRequest || loanRequest.Sum + GetUserLoans(loanRequest.LoanerId)?.Sum(l => l.Sum) > maxAmountPerBorrower)
                continue;

            // Check if the association has enough balance to approve the loan and it doesn't impact future investments
            if (loanRequest.Sum <= todayBalance && !DoesLoanImpactFutureInvestments(loanRequest, approvedLoans, todayBalance))
            {
                IServices.IDeposit deposit = new Implemantation.Deposit();
                if (todayBalance - deposit.GetBalanceDifferenceByTwoDates(DateTime.Today, loanRequest.DateToGetBack) < loanRequest.Sum+30000)
                    continue;
                // Approve the loan
                approvedLoans.Add(loanRequest);

                // Update the available balance
                todayBalance -= loanRequest.Sum;
            }
        }

        // Return the list of approved loans
        return approvedLoans.Any() ? approvedLoans.Where(l => l.IsAprovied == false).Select(l => l.LoanId).ToList() : null;
    }

    public bool IsLoanSafe(int loanId)
    {
        try
        {
            return (bool)(loanDetail.getLoans(l => l.LoanId == loanId).FirstOrDefault()?.Safe);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }
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


    /// <summary>
    /// Helping Function
    /// This function returns all loans requests that in database.
    /// </summary>
    /// <returns></returns>
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
            foreach (Repositories.Models.LoanDetails? l in loanDetail.getLoans(l => l.IsAprovied == true && l.DateToGetBack > date))
            {
                ans.Add(mapper.Map<DTO.Models.Loan>(l));
            }
            return ans;
        }
        catch (Exception ex)
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
            foreach (DTO.Models.Loan? l in GetAllTheLoansByDate(date))
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


    /// <summary>
    /// Helping function.
    /// This function returns the balance of the association for a specific date.  
    /// </summary>
    /// <param name="date"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public double GetTheFinalBalanceByDate(DateTime date)
    {
        try
        {
            // Calculates the Deposits today balance
            Deposit deposit = new Deposit();
            double todayDepositsBalance = deposit.GetTheBalanceByDate(date);
            // Calculates the loans today balance
            double todayLoansBalance = getTheBalanceByDate(date);

            return todayDepositsBalance - todayLoansBalance;// The amount in the association's account that is available for granting loans
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw new Exception("Error: Catch an exception in GetTheFinalBalanceByDate function", ex);
        }

    }


    /// <summary>
    /// This Function checks if the new loan impacts future investments (recursive)
    /// </summary>
    /// <param name="newLoan"></param>
    /// <param name="approvedLoans"></param>
    /// <param name="todayBalance"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public bool DoesLoanImpactFutureInvestments(Loan newLoan, List<Loan> approvedLoans, double todayBalance)
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
            bool doesImpact = CheckFutureInvestmentsImpact(newLoan, loansBeforeNewLoan, todayBalance);

            return doesImpact;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw new Exception("Error: DoesLoanImpactFutureInvestments catch an exception", ex);
        }
    }


    // 
    /// <summary>
    /// Check whether the new loan affects investment returns at future dates
    /// </summary>
    /// <param name="newLoan"></param>
    /// <param name="loansBeforeNewLoan"></param>
    /// <param name="loansAfterNewLoan"></param>
    /// <returns></returns>

    public bool CheckFutureInvestmentsImpact(Loan newLoan, IEnumerable<Loan> loansBeforeNewLoan, double currentBalance)
    {
        //Safety is equal to the sum that is assigned for each user.
        const int Safety = 30000;
        // Sum of new loan request
        double newLoanAmount = newLoan.Sum;
        // Sum of loans to be repaid by this loan repayment date
        double totalLoansBeforeNewLoan = loansBeforeNewLoan.Sum(loan => loan.Sum);
        // Sum of deposits that should be returned in this time frame
        double totalDepositsBeforeLoan = loanDetail.GetDepositsSumByDate(newLoan.DateToGetBack);
        //Returns true if the approval of the current loan jeopardizes the release of the deposits that should be released within this time frame.
        return !((currentBalance - totalDepositsBeforeLoan + totalLoansBeforeNewLoan) - newLoanAmount > Safety);

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
            return loanDetail.Delete(id);
        }
        catch
        {
            return false;
        }
    }

    public bool ReportALoan(int id, bool safe)
    {
        try
        {
            Repositories.Models.LoanDetails? loanDetails = loanDetail.getLoans(l => l.LoanId == id)?.FirstOrDefault();
            if (loanDetails == null)
            {
                Console.WriteLine("User not exist");
                return false;
            }
            loanDetails.Safe = safe;
            return loanDetail.Update(loanDetails);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }
    }
}


    

