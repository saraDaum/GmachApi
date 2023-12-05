using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services;

public static class ServicesConfig
{
    public static void AddBLServices(this IServiceCollection collection)
    {
        collection.AddScoped(typeof(Repositories.Interfaces.IAccount), typeof(Repositories.Implementation.Account));
        collection.AddScoped(typeof(Repositories.Interfaces.IBorrower), typeof(Repositories.Implementation.Borrower));
        collection.AddScoped(typeof(Repositories.Interfaces.ILoanDetails), typeof(Repositories.Implementation.LoanDetails));
        collection.AddScoped(typeof(Repositories.Interfaces.IGuarantor), typeof(Repositories.Implementation.Guarantor));
        collection.AddScoped(typeof(Repositories.Interfaces.IDepositor), typeof(Repositories.Implementation.Depositor));
        collection.AddScoped(typeof(Repositories.Interfaces.IDeposit), typeof(Repositories.Implementation.Deposit));
        collection.AddScoped(typeof(Repositories.Interfaces.IUser), typeof(Repositories.Implementation.User));

        collection.AddDbContext<Repositories.Models.GmachimSaraAndShaniContext>();
    }
}

