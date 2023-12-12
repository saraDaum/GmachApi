using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IServices;

public interface IAccount
{
    /// <summary>
    /// check if user has an account
    /// </summary>
    /// <param name="UserId">the user id</param>
    /// <returns>true/ false</returns>
    bool IsAccountExistByUserId(int UserId);


    /// <summary>
    /// check if account exist by it's id
    /// </summary>
    /// <param name="AccountId">the account Id</param>
    /// <returns>true/ false</returns>
    bool IsAccountExistByAccountId(int AccountId);


    /// <summary>
    /// Add new account to the data-base
    /// </summary>
    /// <param name="account">The account details</param>
    /// <returns>the account id or -1</returns>
    int AddNewAccount(DTO.Models.Account account);


    /// <summary>
    /// Returns all user credit cards that existing in database
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    List<DTO.Models.Account> GetAllCards(int userId);
    
}
