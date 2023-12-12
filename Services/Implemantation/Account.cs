using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implemantation;

public class Account : IServices.IAccount
{
    Repositories.Interfaces.IAccount RepoAccount = new Repositories.Implementation.Account();
    MapperConfig myMapper = MapperConfig.Instance;

    public int AddNewAccount(DTO.Models.Account account)
    {
        try
        {
            // Check if the user exist
            User user = new User();
            if(! user.IsUserExist(account.UserId))
            {
                return -3;
            }
            //Check if the user already has an account
            if (IsAccountExistByUserId(account.UserId))
            {
                return -2;
            }
            IMapper mapper = myMapper.AccountMapper.CreateMapper();
            Repositories.Models.Account a = mapper.Map<Repositories.Models.Account>(account);
            return RepoAccount.AddNewAccount(a);
        }
        catch (Exception ex)
        {
            // Handle exceptions if needed
            Console.WriteLine($"Error checking account existence: {ex.Message}");
            return -1; 
        }
    }

    public bool IsAccountExistByAccountId(int AccountId)
    {
        throw new NotImplementedException();
    }

    public bool IsAccountExistByUserId(int UserId)
    {
        try
        {
            return RepoAccount.checkIfUserHasAccount(UserId);
        }
        catch (Exception ex)
        {
            // Handle exceptions if needed
            Console.WriteLine($"Error checking account existence: {ex.Message}");
            return false; // or throw an exception based on your error handling strategy
        }
    }

    public List<DTO.Models.Account> GetAllCards(int id)
    {
        try
        {
           List<Repositories.Models.Account> allUserCards =  RepoAccount.GetAllUserCards(id);
            IMapper mapper = myMapper.AccountMapper.CreateMapper();
            List<DTO.Models.Account> allCards = allUserCards.ConvertAll<DTO.Models.Account>(card=> mapper.Map<Repositories.Models.Account, DTO.Models.Account>(card));
            return allCards;

        }
        catch
        {
            return new List<DTO.Models.Account>();
        }
    }
}
