using System;
using System.Collections.Generic;

namespace DTO.Models;

public partial class Deposit
{
    public int DepositId { get; set; }

    public int UserId { get; set; }

    public int Sum { get; set; }

    public DateTime DateToPull { get; set; }

    public int CreditCardNumber {  get; set; } = 0;

}

    //TODO: להוסיף פרטי בנק
    //TODO: יומיים לפני המשיכה נשאל במייל האם הוא למשוך או להשאיר כהשקעה ולתת דד ליין חדש
    //public virtual Depositor Depositors { get; set; } = null!;