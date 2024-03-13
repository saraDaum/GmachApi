using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces;

public interface ICard
{
    /// <summary>
    /// Check if the user already has a credit card in the system
    /// </summary>
    /// <param name="UserId">The user id</param>
    /// <returns>true/ false</returns>
    bool CheckIfUserHasCard(int UserId);


    /// <summary>
    /// Add new card
    /// </summary>
    /// <param name="account">card to add</param>
    /// <returns>card Id</returns>
    int AddNewCard(Models.Card card);

    List<Repositories.Models.Card> GetAllUserCards(int id);

    /// <summary>
    /// Return all cards in database.
    /// </summary>
    /// <returns></returns>
    List<Repositories.Models.Card> GetAllCards();

    public void EncryptDataBase();

}


