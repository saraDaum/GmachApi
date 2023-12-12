using Microsoft.EntityFrameworkCore;
using Repositories.Models;

namespace Repositories;

public interface IDbContext
{
    DbSet<Account> Accounts { get; set; }
    
    DbSet<Users> Users { get; set; }

    DbSet<Deposit> Deposits { get; set; }

    DbSet<Guarantor> Guarantors { get; set; }

    DbSet<LoanDetails> LoanDetails { get; set; }

    DbSet<UsersUnderWarning> UsersUnderWarning { get; set; }

    int SaveChanges();
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    //Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
}