using AutoMapper;
using Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;


namespace Services.Implemantation;

public class Deposit : IServices.IDeposit
{
    MapperConfig myMapper = MapperConfig.Instance;
    Repositories.Implementation.Deposit reposDeposit = new Repositories.Implementation.Deposit();

    public IEnumerable<DTO.Models.Deposit> AllUserDeposits(int id)
    {
        try
        {
            IEnumerable<Repositories.Models.Deposit> allDeposits = reposDeposit.AllUserDeposits(id);
            ArgumentNullException.ThrowIfNull(allDeposits);// Continue just if it is not null.
            IMapper mapper = myMapper.DepositsMapper.CreateMapper();
            return  allDeposits.Select(deposit => mapper.Map<Repositories.Models.Deposit, DTO.Models.Deposit>(deposit));
        }
        catch (Exception ex)
        {
            return Enumerable.Empty<DTO.Models.Deposit>();
            throw new Exception(ex.Message);
        }

    }


    /// <summary>
    /// Handling the deposit procces
    /// </summary>
    /// <param name="newDeposit">deposit details</param>
    /// <returns></returns>
    public int AddADeposit(DTO.Models.Deposit newDeposit)
    {
        try
        {
            //find out that the user exists
            User user = new User();
            if (!user.IsUserExist(newDeposit.UserId))
            {
                return -2;
            }

            //TODO: Uncomment this lines.
            //make sure that the user has a bank account in the system.
           // Account account = new Account();
            //if(!account.IsAccountExistByUserId(newDeposit.UserId))
            //{
              //  return -3;
           // }

            //add the deposit
            IMapper mapper = myMapper.DepositsMapper.CreateMapper();
            Repositories.Models.Deposit newRepoDeposit = mapper.Map<DTO.Models.Deposit, Repositories.Models.Deposit>(newDeposit);
            ArgumentNullException.ThrowIfNull(newRepoDeposit);// Continue just if it is not null.
            int res = reposDeposit.AddADeposit(newRepoDeposit);
            if (res == 1)
            {
                return newRepoDeposit.DepositId;
            }
            return -1;
        }
        catch
        {
            return -1;
        }
    }

    /// <summary>
    /// Returns all users deposits in data base.
    /// </summary>
    /// <returns></returns>
    public List<DTO.Models.Deposit> GetAll()
    {
        try
        {
            IEnumerable<Repositories.Models.Deposit> allUsersDeposits = reposDeposit.GetAll();
            ArgumentNullException.ThrowIfNull(allUsersDeposits);// Continue just if it is not null.
            IMapper mapper = myMapper.DepositsMapper.CreateMapper();
            return allUsersDeposits.Select(deposit => mapper.Map<Repositories.Models.Deposit, DTO.Models.Deposit>(deposit)).ToList();
        }
        catch
        {
            return new List<DTO.Models.Deposit>();
        }
    }

    public IEnumerable<DTO.Models.Deposit>? GetAllTheDepositsByDate(DateTime date)
    {
        try
        {
            // get all the dposit according to specific day (All deposits that dateToPull bigger than today)
            List<Repositories.Models.Deposit>? deposits = reposDeposit.GetAllTheDepositsByDate(date);
            ArgumentNullException.ThrowIfNull(deposits);

            //convert the deposits type.
            IMapper mapper = myMapper.DepositsMapper.CreateMapper();
            List<DTO.Models.Deposit> ans = new List<DTO.Models.Deposit>();
            foreach(Repositories.Models.Deposit d in deposits)
            {
                 ans.Add(mapper.Map<DTO.Models.Deposit>(d));
            }
            return ans;
        }
        catch(Exception ex) 
        {
            Console.WriteLine(ex.ToString());
            return null;
        }
    }

    public double GetTheBalanceByDate(DateTime date)
    {
        try
        {
            double balance = 0;
            foreach(DTO.Models.Deposit d in GetAllTheDepositsByDate(date))
            {
                balance += d.Sum;
            }
            return balance;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            throw new Exception("Error: in get balance of deposit by date function", ex);
        }
    }

    public double GetBalanceDifferenceByTwoDates(DateTime date1, DateTime date2)
    {
        try
        {
            return GetTheBalanceByDate(date1) - GetTheBalanceByDate(date2);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            throw new Exception("Error: Catch an exception in GetBalanceByTwoDates function.", ex);
        }
    }
}