using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces;

public interface IAccount
{
    /// <summary>
    /// Check if the user already has a bank account in the system
    /// </summary>
    /// <param name="UserId">The user id</param>
    /// <returns>true/ false</returns>
    bool checkIfUserHasAccount(int UserId);


    /// <summary>
    /// Add new account
    /// </summary>
    /// <param name="account">Account to add</param>
    /// <returns>Account Id</returns>
    int AddNewAccount(Models.Account account);


    /// <summary>
    /// Returns a List with all users accounts in database
    /// </summary>
    /// <returns></returns>
    List<Models.Account> GetAllAccounts();
}
