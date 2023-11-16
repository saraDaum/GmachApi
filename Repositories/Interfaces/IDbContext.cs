﻿using Microsoft.EntityFrameworkCore;
using Repositories.Models;

namespace Repositories;

public interface IDbContext
{
    DbSet<Account> Acounts { get; set; }
    
    DbSet<User> User { get; set; }

    DbSet<Borrower> Borrowers { get; set; }

    DbSet<Deposit> Deposits { get; set; }

    DbSet<Depositor> Depositors { get; set; }

    DbSet<Guarantor> Guarantors { get; set; }

    DbSet<LoanDetails> LoanDetails { get; set; }

    
    int SaveChanges();
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    //Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
}