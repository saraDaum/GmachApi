using DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IServices;

public interface IDeposit
{
    int AddADeposit(Deposit newDeposit);
    IEnumerable<Deposit> AllUserDeposits(int id);
    List<Deposit> GetAll();


    /// <summary>
    /// Get all the Deposits that exist in specipic date.
    /// </summary>
    /// <param name="date">the date</param>
    /// <returns>list of the deposits.</returns>
    IEnumerable<Deposit>? GetAllTheDepositsByDate(DateTime date);


    /// <summary>
    /// return the balance of specific date (the deposits only)
    /// </summary>
    /// <param name="date">the date</param>
    /// <returns>the balance</returns>
    double getTheBalanceByDate(DateTime date);


}
