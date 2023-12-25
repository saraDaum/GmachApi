using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IServices;

public interface ICard
{
    /// <summary>
    /// check if user has an account
    /// </summary>
    /// <param name="UserId">the user id</param>
    /// <returns>true/ false</returns>
    bool IsCardExistByUserId(int UserId);





    /// <summary>
    /// Add new account to the data-base
    /// </summary>
    /// <param name="account">The account details</param>
    /// <returns>the account id or -1</returns>
    int AddNewCard(DTO.Models.Card account);


    /// <summary>
    /// Returns all user credit cards that existing in database
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    List<DTO.Models.Card> GetAllCards(int userId);
    
}
