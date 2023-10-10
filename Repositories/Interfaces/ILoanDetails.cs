﻿using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces;

public interface ILoanDetail
{
    public int AddLoan(Models.LoansDetail loansDetail);
    public Models.LoansDetail GetLoansDetail(int userId);
}