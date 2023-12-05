using AutoMapper;
using Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
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

            //make sure that the user has a bank account in the system.
            Account account = new Account();
            if(!account.IsAccountExistByUserId(newDeposit.UserId))
            {
                return -3;
            }

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


}