using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Models;

public class Loan
{
    public int LoanId { get; set; }
    public int LoanerId { get; set; }
    public DateTime DateToGetBack { get; set; }
    public int Sum { get; set; }
    public string LoanFile { get; set; } = string.Empty;
    public bool IsAprovied { get; set; }

    public Loan() { }

    public Loan(int loanId, int userId, DateTime dateToGetBack, int sum, string loanFile, bool isAprovied)
    {
        LoanId=loanId;
        LoanerId=userId;
        DateToGetBack=dateToGetBack;
        Sum=sum;
        LoanFile=loanFile;
        IsAprovied=isAprovied;
    }
}
