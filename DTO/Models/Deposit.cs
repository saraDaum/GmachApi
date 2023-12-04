using System;
using System.Collections.Generic;

namespace DTO.Models;

public partial class Deposit
{
    //TODO: להוסיף פרטי בנק
    //TODO: יומיים לפני המשיכה נשאל במייל האם הוא למשוך או להשאיר כהשקעה ולתת דד ליין חדש
    public int DepositId { get; set; }

    public int UserId { get; set; }

    public int Sum { get; set; }

    public DateTime DateToPull { get; set; }

    //public virtual Depositor Depositors { get; set; } = null!;
}
